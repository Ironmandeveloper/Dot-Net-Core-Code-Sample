using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.OrderDtos
{
    public class OrderDto
    {
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; }
        public int Total { get; set; }
    }
}
