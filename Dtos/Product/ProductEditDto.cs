using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Product
{
    public class ProductEditDto
    {
            public int Id { get; set; }
            public string TypeName { get; set; }
            public string Name { get; set; }
            public int TypeId { get; set; }
            public string Image { get; set; }
            public string Price { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
            public IFormFile file { get; set; }
        public string MetaInfo { get; set; }
        public string MetaTitle { get; set; }
        public string UrlReferer { get; set; }
        public string Icon { get; set; }
        public List<SelectListItem> ProductTypes { get; set; }
    }
    public class Itemlist1
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
