using Dtos.Faq;
using Dtos.ReviewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Product
{
    public class ProductDetialVm
    {
        public List<ProductByTypeDto> model { get; set; }
        public List<FaqDto>? Faq { get; set; }

        public ProductEditDto? productDet { get; set; }
        public List<ReviewListDto> ReviewListDtos { get; set; }
    }
}
