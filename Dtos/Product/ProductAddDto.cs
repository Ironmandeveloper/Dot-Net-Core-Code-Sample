using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Product
{
    public class ProductAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ProductTypeId { get; set; }
        public IFormFile Image { get; set; }
        public string ProductDescription { get; set; }
        public string MetaInfo { get; set; }
        public string MetaTitle { get; set; }
        public string UrlReferer { get; set; }
        public string Status { get; set; }
    }
}
