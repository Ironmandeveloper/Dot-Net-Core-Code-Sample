using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Order
{
    public class Order:IBaseClass
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get ; set ; }
        public bool IsActive { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime UpdatedOn { get ; set ; }
        public string CreatedBy { get ; set ; }
        public string UpdatedBy { get ; set ; }
    }
}
