using DataModels.Models.Product;
using DataModels.Models.Review;
using Dtos.Faq;
using Dtos.Product;
using E_Comm.Helpers;
using E_Comm.Helpers.ExceptionHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.FaqServices;
using Services.FileHandlingServices;
using Services.ProductServices;
using Services.ProductTypeServices;
using Services.ReviewServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks; 

namespace E_Comm.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFileHandlingService _fileHandlingService;
        private readonly IWebHostEnvironment _env;
        private readonly IProductTypeService _productTypeService;
        private readonly IFaqService _faqService;
        private readonly IReviewService _reviewService;
        public ProductsController(IProductService productService, IReviewService reviewService, IProductTypeService productTypeService, IWebHostEnvironment env, IFileHandlingService fileHandlingService, IFaqService faqService)
        {
            _productService = productService;
            _fileHandlingService = fileHandlingService;
            _env = env;
            _productTypeService = productTypeService;
            _faqService = faqService;
            _reviewService = reviewService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Filter_Products()
        {
            return View(_productService.GetAllProducts());
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Product_listing()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Product_Details(int productId)
        {

            var model = new ProductDetialVm();

            model.Faq = _faqService.GetFaqs().Result.Select(x => new FaqDto
            {
                Question = x.Question,
                Answer = x.Answer
            }).ToList();

            model.productDet = _productService.GetProductById(productId);
            model.ReviewListDtos =await _reviewService.Get(productId);
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddReview(Review review) 
        {
            await _reviewService.Create(review);
            return Json("review has been added successfully");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var keyValPairs=await _productTypeService.GetKeyValPairs();
            ViewBag.ProductTypes = keyValPairs.Select(x => new SelectListItem
            {
                Text=x.Text,
                Value=x.Value
            }).ToList();
            return View(_productService.GetProducts());
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AlreadyExists(string ProductName)
        {
            if (await _productService.AlreadyExists(ProductName))
            {
                return Json(new { message = "Already exists" });
            }
            else
            {
                return Json(new { message = "Does not exists" });
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var Product = _productService.GetProductById(Id);
            Product.ProductTypes = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            var ProductTypes = await _productTypeService.GetKeyValPairs();
            Product.ProductTypes = ProductTypes.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() }).ToList();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "AddOrEdit", Product) });

        }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult FetchProductsByType(int TypeId)
        {
            return View(_productService.FetchProductByTypeId(TypeId));
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update([Bind("Id,Name,TypeId,file,Description,Price,IsActive,Image,MetaInfo,MetaTitle,UrlReferer")] [FromForm] ProductEditDto product)
        {
            try
            {
                if (product.Id == 0)
                {
                    return Json(new { message = "Id wasn't provided" });
                }
                else
                {
                    if (product.file != null)
                    {
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                        if (!_fileHandlingService.ValidateFileExtension(allowedExtensions, product.file.FileName))
                        {
                            return Ok(new
                            {
                                message = "File you provided is of wrong extension, Allowed extensions are "
                                + String.Join(", ", allowedExtensions),
                                StatusCode = StatusCodes.Status400BadRequest,
                                isValid = false
                            });
                        }
                        var postedFile = product.file;

                        string fileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToString("dd-MMM-yyyy_HH-mm-ss") + "_" + postedFile.FileName;
                        string StoragePath = System.IO.Path.Combine(_env.WebRootPath + "/Product/" + fileName);
                        _fileHandlingService.SaveFileOnServer(postedFile, _env.WebRootPath + "/Product/", StoragePath);

                        await _productService.Update(new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            UpdatedBy = GetLoggedUserId(),
                            UpdatedOn = DateTime.Now,
                            Description = product.Description,
                            Price = product.Price,
                            IsActive = product.IsActive,
                            ProductTypeId = product.TypeId,
                            Image = fileName,
                            MetaTitle=product.MetaTitle,
                            MetaInfo=product.MetaInfo,
                            UrlReferer=product.UrlReferer
                        });
                        _fileHandlingService.DeleteFileOnServer(_env.WebRootPath + "/" + product.Image);
                        var keyValPairs = await _productTypeService.GetKeyValPairs();
                        ViewBag.ProductTypes = keyValPairs.Select(x => new SelectListItem
                        {
                            Text = x.Text,
                            Value = x.Value
                        }).ToList();
                        return Json(new
                        {
                            isValid = true,
                            html = Helper.RenderRazorViewToString(this, "_ViewAll", _productService.GetProducts()),
                            htmll = await this.RenderViewToStringAsync("/Views/Products/_AddPartial.cshtml")
                        });
                    }
                    else
                    {

                        await _productService.Update(new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            UpdatedBy = GetLoggedUserId(),
                            UpdatedOn = DateTime.Now,
                            Description = product.Description,
                            Price = product.Price,
                            IsActive = product.IsActive,
                            ProductTypeId = product.TypeId,
                            Image = product.Image,
                            MetaTitle = product.MetaTitle,
                            MetaInfo = product.MetaInfo,
                            UrlReferer = product.UrlReferer
                        });
                        var keyValPairs = await _productTypeService.GetKeyValPairs();
                        ViewBag.ProductTypes = keyValPairs.Select(x => new SelectListItem
                        {
                            Text = x.Text,
                            Value = x.Value
                        }).ToList();
                        return Json(new
                        {
                            isValid = true,
                            html = Helper.RenderRazorViewToString(this, "_ViewAll", _productService.GetProducts()),
                            htmll = await this.RenderViewToStringAsync("/Views/Products/_AddPartial.cshtml")
                        });
                    }
                }
            }
            catch(Exception x)
            {
                using (StreamWriter w = System.IO.File.AppendText("Product-Update.txt"))
                {
                   Logger.Log(""+x.Message.ToString(), w);
                }
                return Json(new
                {
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", _productService.GetProducts()),
                    htmll = await this.RenderViewToStringAsync("/Views/Products/_AddPartial.cshtml")
                });
            }
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(ProductAddDto model)
        {
            try
            {
                if (model.Id == 0)
                {
                    if (model.Image != null)
                    {
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                        if (!_fileHandlingService.ValidateFileExtension(allowedExtensions, model.Image.FileName))
                        {
                            return Ok(new
                            {
                                message = "File you provided is of wrong extension, Allowed extensions are "
                                + String.Join(", ", allowedExtensions),
                                StatusCode = StatusCodes.Status400BadRequest,
                                isValid = false
                            });
                        }
                        var postedFile = model.Image;
                        string fileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToString("dd-MMM-yyyy_HH-mm-ss") + "_" + postedFile.FileName;
                        string StoragePath = System.IO.Path.Combine(_env.WebRootPath + "/Product/" + fileName);
                        _fileHandlingService.SaveFileOnServer(postedFile, _env.WebRootPath + "/Product/", StoragePath);
                        await _productService.Create(new DataModels.Models.Product.Product
                        {
                            IsActive = Convert.ToBoolean(model.Status),
                            Name = model.Name,
                            CreatedBy = GetLoggedUserId(),
                            CreatedOn = DateTime.Now,
                            IsDeleted = false,
                            UpdatedBy = GetLoggedUserId(),
                            UpdatedOn = DateTime.Now,
                            Description = model.ProductDescription,
                            Image = fileName,
                            Price = model.Price,
                            ProductTypeId = Convert.ToInt32(model.ProductTypeId),
                            MetaTitle=model.MetaTitle,
                            MetaInfo=model.MetaInfo,
                            UrlReferer=model.UrlReferer
                        });
                        return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _productService.GetProducts()) });
                    }
                    else
                    {
                        await _productService.Create(new DataModels.Models.Product.Product
                        {
                            IsActive = Convert.ToBoolean(model.Status),
                            Name = model.Name,
                            CreatedBy = GetLoggedUserId(),
                            CreatedOn = DateTime.Now,
                            IsDeleted = false,
                            UpdatedBy = GetLoggedUserId(),
                            UpdatedOn = DateTime.Now,
                            Description = model.ProductDescription,
                            Image = String.Empty,
                            Price = model.Price,
                            ProductTypeId = Convert.ToInt32(model.ProductTypeId),
                            MetaTitle = model.MetaTitle,
                            MetaInfo = model.MetaInfo,
                            UrlReferer = model.UrlReferer
                        });
                    }
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _productService.GetProducts()) });
                }
                else
                {
                    var Product = _productService.GetProductById(model.Id);
                    Product.ProductTypes = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
                    var ProductTypes = await _productTypeService.GetKeyValPairs();
                    Product.ProductTypes = ProductTypes.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() }).ToList();
                    //var a = Helper.RenderRazorViewToString(this, "AddOrEdit", Product);
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "AddOrEdit", Product) });
                }
            }catch(Exception x)
            {
                using (StreamWriter w = System.IO.File.AppendText("Product-AddOrEdit.txt"))
                {
                    Logger.Log(x.Message.ToString(), w);
                }
                return Json(new { isValid = true, message = "INTERNAL SERVER ERROR" });
            }
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var keyValPairs = await _productTypeService.GetKeyValPairs();
            ViewBag.ProductTypes = keyValPairs.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            await _productService.Delete(Id);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _productService.GetProducts()),
            htmll = await this.RenderViewToStringAsync("/Views/Products/_AddPartial.cshtml")
            });
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ResetHandler() 
        {
            var keyValPairs = await _productTypeService.GetKeyValPairs();
            ViewBag.ProductTypes = keyValPairs.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            return Json(new
            {
                isValid = true,
                html = await this.RenderViewToStringAsync("/Views/Products/_AddPartial.cshtml")
            });
        }
        public string GetLoggedUserId()
        {
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Identities.First().Claims.ElementAt(0).Value.ToString();

            return userId;
        }
    }
}
