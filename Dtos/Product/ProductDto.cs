using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlReferer { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
