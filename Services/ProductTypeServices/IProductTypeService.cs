using DataModels.Models;
using Dtos.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductTypeServices
{
    public interface IProductTypeService
    {
        Task<List<KeyValPair>> GetKeyValPairs(); 
        Task<List<ProductType>> GetProductTypeList();
        Task<string> Create(ProductType productType);
        Task<bool> AlreadyExists(string ProductType,string UrlReferer);
        Task<ProductType> GetProductTypeById(int ProductTypeId);
        Task<string> Update(ProductType productType);
        Task<string> Delete(int Id);
    }
}
