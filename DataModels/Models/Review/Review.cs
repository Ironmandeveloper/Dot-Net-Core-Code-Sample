using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Review
{
    public  class Review:IBaseClass
    {
        public int Reviewid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Reviews { get; set; }

        public string Rating { get; set; }
        public int ProductId { get; set; }
        public DataModels.Models.Product.Product? Product { get; set; }

        public bool IsDeleted { get ; set ; }
        public bool IsActive { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime UpdatedOn { get ; set ; }
        public string CreatedBy { get ; set ; }
        public string UpdatedBy { get ; set ; }
    }
}
