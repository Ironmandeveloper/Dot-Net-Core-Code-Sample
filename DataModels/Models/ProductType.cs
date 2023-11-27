using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class ProductType: IBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetaInfo { get; set; }
        public string MetaTitle { get; set; }
        public string UrlReferer { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public ICollection<DataModels.Models.Product.Product>? Products { get; set; }
    }
}
