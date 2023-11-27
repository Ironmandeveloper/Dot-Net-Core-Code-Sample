using DataModels.Models;
using Dtos.ProductType;
using E_Comm.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ProductServices;
using Services.ProductTypeServices;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks; 

namespace E_Comm.Controllers
{
    [Authorize]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;

        private readonly IProductService _productService;
        public ProductTypeController(IProductTypeService productTypeService,IProductService productService) 
        {
            _productTypeService = productTypeService;
            _productService = productService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _productTypeService.GetProductTypeList());
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AlreadyExists(string ProductName,string UrlReferer)
        {
            if (await _productTypeService.AlreadyExists(ProductName,UrlReferer))
            {
                return Json(new { message="Already exists" });
            }
            else
            {
                return Json(new { message = "Does not exists" });
            }
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(ProductTypeAddDto model)
        {
            if (model.Id == 0)
            {
                await _productTypeService.Create(new DataModels.Models.ProductType
                {
                    IsActive = model.Status,
                    Name = model.ProductName,
                    CreatedBy = GetLoggedUserId(),
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    UpdatedBy = GetLoggedUserId(),
                    UpdatedOn = DateTime.Now,
                    UrlReferer=model.UrlReferer,
                    MetaInfo=model.MetaInfo,
                    MetaTitle=model.MetaInfo
                });
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _productTypeService.GetProductTypeList()) });
            }
            else
            {
                var ProductType = await _productTypeService.GetProductTypeById(model.Id);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "AddOrEdit", ProductType) });
            }

        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetKeyValPair()
        {
            return Json(await _productTypeService.GetKeyValPairs());
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Name,MetaInfo,MetaTitle,UrlReferer,IsActive")] ProductType productType)
        {
            if(productType.Id==0) 
            {
                return Json(new { message="Id wasn't provided" });
            }
            else 
            {
                productType.UpdatedBy = GetLoggedUserId();
                productType.UpdatedOn = DateTime.Now;
                var res=await _productTypeService.Update(productType);
                if(res== "Product type with same name or refferer already exists")
                {
                    return Json(new { isValid = false, message = res });
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _productTypeService.GetProductTypeList()) });
            }
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var response = await _productTypeService.Delete(Id);
            if (response == "Please delete all the products in this type in order to delete it")
            {
                return Json(new { isValid = false, html = response });
            }
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _productTypeService.GetProductTypeList()) });
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
