using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Product
{
    public class ProductByTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetaDescription { get; set; }
        public string MetaIcon { get; set; }
        public string MetaTitle { get; set; }
        public string ProductTypeName { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }
}
