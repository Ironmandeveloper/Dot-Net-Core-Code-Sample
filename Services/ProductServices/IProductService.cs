using DataModels.Models.Product;
using Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServices
{
    public interface IProductService
    {
        List<ProductByTypeDto> FetchProductByTypeId(int TypeId);
        Task<List<ProductByTypeDto>> FetchProductByTypeName(string UrlReferer);
        Task<bool> ProductExistsInProductType(int ProductTypeId);
        Task<string> DeleteProductByTypeId(int ProductTypeId);
        List<ProductDto> GetProducts();
        List<ProductDto> GetTop8Products();
        List<ProductDto> GetAllProducts();
        Task<bool> AlreadyExists(string ProductName);
        Task<string> Create(Product productType);
        ProductEditDto GetProductById(int? Id);
        Task<ProductEditDto> GetProductByName(string name);
        Task<string> Update(Product product); 
        Task<string> Delete(int Id);
    }
}
