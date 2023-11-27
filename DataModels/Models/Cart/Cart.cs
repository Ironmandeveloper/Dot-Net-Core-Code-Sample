using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Cart
{
    public class Cart
    {
        public int CartId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
