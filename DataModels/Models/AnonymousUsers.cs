using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class AnonymousUsers: IBaseClass
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get ; set ; }
        public bool IsActive { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime UpdatedOn { get ; set ; }
        public string CreatedBy { get ; set ; }
        public string UpdatedBy { get ; set ; }
        public ICollection<DataModels.Models.Cart.Cart>? Carts { get; set; }
    }
}
