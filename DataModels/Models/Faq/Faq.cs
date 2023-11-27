using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Faq
{
    public class Faq:IBaseClass
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsDeleted { get ; set ; }
        public bool IsActive { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime UpdatedOn { get ; set ; }
        public string CreatedBy { get ; set ; }
        public string UpdatedBy { get ; set ; }
    }
}
