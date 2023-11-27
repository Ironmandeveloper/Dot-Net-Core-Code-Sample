using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ProductType
{
    public class ProductTypeAddDto
    {
        public int Id { get; set; }
        public string MetaTitle { get; set; }
        public string ProductName { get; set; }
        public string UrlReferer { get; set; }
        public string MetaInfo { get; set; }
        public bool Status  { get; set; }
    }
}
