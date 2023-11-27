using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Product
{
    public class Product:IBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType? ProductType{ get; set; }
        public string MetaInfo { get; set; }
        public string MetaTitle { get; set; }
        public string UrlReferer { get; set; }
        public bool IsDeleted { get ; set ; }
        public bool IsActive { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime UpdatedOn { get ; set ; }
        public string CreatedBy { get ; set ; }
        public string UpdatedBy { get ; set ; }

        public ICollection<DataModels.Models.Review.Review>? Reviews { get; set; }
    }
}
