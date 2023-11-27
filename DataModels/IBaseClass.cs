using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataModels
{
    public interface IBaseClass
    {
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; } 
        public string UpdatedBy { get; set; } 
    }
}
