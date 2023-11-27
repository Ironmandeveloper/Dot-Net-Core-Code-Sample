using DataModels.DAL;
using DataModels.Models;
using Dtos.ProductType;
using Microsoft.EntityFrameworkCore;
using Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductTypeServices
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductService _productService;
        public ProductTypeService( ApplicationDBContext context,IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task<bool> AlreadyExists(string ProductType, string UrlReferer)
        {
            if(await _context.ProductTypes.Where(x => x.Name.Equals(ProductType)||x.UrlReferer.Equals(UrlReferer)).CountAsync() > 0)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<string> Create(ProductType productType)
        {
            if (productType.Name.Length > 50)
            {
                return "Type Name should be less than 50 characters";
            }
            await _context.ProductTypes.AddAsync(productType);
            await _context.SaveChangesAsync();
            return "Product Type has been added successfully";
        }

        public async Task<string> Delete(int Id)
        {
            try
            {
                var productType = await _context.ProductTypes.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
                if (productType == null)
                {
                    return "Product type doesn't exists";
                }
                if (await _productService.ProductExistsInProductType(Id))
                {
                    return "Please delete all the products in this type in order to delete it";
                }

                _context.ProductTypes.Remove(productType);
                await _context.SaveChangesAsync();
                return "Product Type has been deleted Successfully";
            }
            catch (Exception) { throw; }
        }


        public async Task<List<KeyValPair>> GetKeyValPairs()
        {
            return await _context.ProductTypes.Where(x=>x.IsActive==true&&x.IsDeleted==false)
                .Select(x=>new KeyValPair { 
                Value =x.Id.ToString(),
                Text = x.Name
                }).
                ToListAsync();
        }

        public async Task<ProductType> GetProductTypeById(int ProductTypeId)
        {
            var ProductType = await _context.ProductTypes.Where(x => x.Id == ProductTypeId).FirstOrDefaultAsync();
            if (ProductType == null)
            {
                return new ProductType();
            }
            else
            {
                return ProductType;
            }
        }

        public async Task<List<ProductType>> GetProductTypeList()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<string> Update(ProductType productType)
        {
            var exists = await _context.ProductTypes.Where(x => x.UrlReferer.Equals(productType.UrlReferer) || x.Name.Equals(productType.Name)).CountAsync();
            if (exists > 1)
            {
                return "Product type with same name or refferer already exists";
            }
            var ProductType = await _context.ProductTypes.Where(x => x.Id == productType.Id).FirstOrDefaultAsync();
            if (ProductType == null)
            {
                return "Product type doesn't exists";
            }
            ProductType.Name = productType.Name;
            ProductType.IsActive = productType.IsActive;
            ProductType.UrlReferer = productType.UrlReferer;
            ProductType.MetaInfo = productType.MetaInfo;
            ProductType.MetaTitle = productType.MetaTitle;
            _context.ProductTypes.Update(ProductType);
            await _context.SaveChangesAsync();
            return "Product type has been updated successfully";
        }
    }
}
