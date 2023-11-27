using DataModels.DAL;
using DataModels.Models.Product;
using Dtos.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductService(ApplicationDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<bool> AlreadyExists(string ProductName)
        {
            if (await _context.Products.Where(x => x.Name == ProductName).CountAsync() > 0)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<string> Create(Product product)
        {
            if (product.Name.Length > 50)
            {
                return "Product Name should be less than 50 characters";
            }
            if (product.Image == string.Empty)
            {
                product.Image = "Not Available";
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return "Product has been added successfully";
        }

        public ProductEditDto GetProductById(int? Id)
        {
            var Product = (from p in _context.Products
                            join pt in _context.ProductTypes on p.ProductTypeId equals pt.Id
                            where (p.Id == Id)
                            select new ProductEditDto
                            {
                                Id = p.Id,
                                Description = p.Description,
                                Image = p.Image,
                                Name = p.Name,
                                TypeName = pt.Name,
                                Price = p.Price,
                                TypeId = pt.Id,
                                IsActive = p.IsActive,
                                MetaInfo=p.MetaInfo,
                                MetaTitle=p.MetaTitle,
                                UrlReferer=p.UrlReferer
                            }).FirstOrDefault();
            if (Product == null) return new ProductEditDto();
            return Product;
        }
        public List<ProductDto> GetTop8Products()
        {
            var Products = (from p in _context.Products
                            join pt in _context.ProductTypes on p.ProductTypeId equals pt.Id
                            select new ProductDto
                            {
                                Id = p.Id,
                                Description = p.Description,
                                Image = p.Image,
                                Name = p.Name,
                                Price = p.Price,
                                Type = pt.Name,
                                IsActive = p.IsActive,
                                UrlReferer=p.UrlReferer
                            }).Take(8).ToList();
            return Products;
        }

        public List<ProductDto> GetProducts()
        {
            var Products = (from p in _context.Products
                            join pt in _context.ProductTypes on p.ProductTypeId equals pt.Id
                            select new ProductDto
                            {
                                Id = p.Id,
                                Description =p.Description,
                                Image=p.Image,
                                Name=p.Name,
                                Price=p.Price,
                                Type=pt.Name,
                                IsActive=p.IsActive
                              }).ToList();
            return Products;
        }

        public List<ProductDto> GetAllProducts()
        {
            var Products = (from p in _context.Products
                            join pt in _context.ProductTypes on p.ProductTypeId equals pt.Id
                            select new ProductDto
                            {
                                Id = p.Id,
                                Description = p.Description,
                                Image = p.Image,
                                Name = p.Name,
                                Price = p.Price,
                                Type = pt.Name,
                                IsActive = p.IsActive
                            }).ToList();
            return Products;
        }

        public async Task<string> Update(Product product)
        {
            var Product = await _context.Products.Where(x => x.Id == product.Id).FirstOrDefaultAsync();
            if (Product == null)
            {
                return "Product doesn't exists";
            }
            Product.Name = product.Name;
            Product.Price = product.Price;
            Product.Description = product.Description;
            Product.IsActive = product.IsActive;
            Product.UpdatedOn = product.UpdatedOn;
            Product.UpdatedBy = product.UpdatedBy;
            if (product.Image != String.Empty)
            {
                Product.Image = product.Image;
            }
            Product.ProductTypeId = product.ProductTypeId;
            Product.MetaInfo = product.MetaInfo;
            Product.MetaTitle = product.MetaTitle;
            Product.UrlReferer = product.UrlReferer;
            _context.Products.Update(Product);
            await _context.SaveChangesAsync();
            return "Product type has been updated successfully";
        }
        public async Task<string> Delete(int Id)
        {
            var product = await _context.Products.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
            if (product == null)
            {
                return "Product doesn't exists";
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return "Product has been deleted Successfully";
        }

        public async Task<string> DeleteProductByTypeId(int ProductTypeId)
        {
            var Products = await _context.Products.Where(x => x.ProductTypeId == ProductTypeId).ToListAsync();
            _context.Products.RemoveRange(Products);
            await _context.SaveChangesAsync();
            return "Product assosiated with this type has been deleted successfully";
        }

        public async Task<bool> ProductExistsInProductType(int ProductTypeId)
        {
            var Count = await _context.Products.Where(x => x.ProductTypeId == ProductTypeId).CountAsync();
            if (Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ProductByTypeDto> FetchProductByTypeId(int TypeId)
        {
            var Products = (from p in _context.Products
                            join pt in _context.ProductTypes on p.ProductTypeId equals pt.Id
                            where pt.Id.Equals(TypeId)
                            select new ProductByTypeDto
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Price = p.Price,
                                Image=p.Image
                            }).ToList();
            return Products;
        }
        public static string GetDataURL(string imgFile)
        {
            return "data:image/"
                        + Path.GetExtension(imgFile).Replace(".", "")
                        + ";base64,"
                        + imgFile;
        }
        public async Task<List<ProductByTypeDto>> FetchProductByTypeName(string UrlReferer)
        {
            using (WebClient client = new WebClient())
            {
                byte[] bytes = await client.DownloadDataTaskAsync(_env.WebRootPath + @"\images\icons8-bitcoin-accepted-64.png");
                var imgBytes = Convert.ToBase64String(bytes);
                var image = GetDataURL(imgBytes);

                var ProductType = await _context.ProductTypes.Where(x => x.UrlReferer.Equals(UrlReferer)).FirstOrDefaultAsync();
                if (ProductType == null) { return new List<ProductByTypeDto>(); }
                var Products = (from p in _context.Products
                                join pt in _context.ProductTypes on p.ProductTypeId equals pt.Id
                                where pt.Id.Equals(ProductType.Id)
                                select new ProductByTypeDto
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Price = p.Price,
                                    Image = p.Image,
                                    ProductTypeName = ProductType.Name,
                                    MetaDescription = pt.MetaInfo,
                                    MetaIcon = image,
                                    MetaTitle=pt.MetaTitle
                                }).ToList();

                return Products;
            }
        }

        public async Task<ProductEditDto> GetProductByName(string name)
        {
            using (WebClient client = new WebClient())
            {
                //byte[] bytes = await client.DownloadDataTaskAsync(_env.WebRootPath + @"\images\icons8-bitcoin-accepted-64.png");
                //var imgBytes = Convert.ToBase64String(bytes);
                //var image = GetDataURL(imgBytes);

                var Product = (from p in _context.Products
                               join pt in _context.ProductTypes on p.ProductTypeId equals pt.Id
                               where (p.UrlReferer == name)
                               select new ProductEditDto
                               {
                                   Id = p.Id,
                                   Description = p.Description,
                                   Image = p.Image,
                                   Name = p.Name,
                                   TypeName = pt.Name,
                                   Price = p.Price,
                                   TypeId = pt.Id,
                                   IsActive = p.IsActive,
                                   MetaTitle = p.MetaTitle,
                                   MetaInfo = p.MetaInfo,
                                   UrlReferer = p.UrlReferer,
                                   //Icon=image
                               }).FirstOrDefault();
                if (Product == null) return new ProductEditDto();
                return Product;
            }
        }
    }
}
