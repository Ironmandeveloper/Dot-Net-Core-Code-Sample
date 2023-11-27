using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ReviewDtos
{
    public class ReviewAdminListDto
    {
        public int Reviewid { get; set; }

        public string FullName { get; set; }

        public string ProductName { get; set; }

        public string Email { get; set; }

        public string Reviews { get; set; }

        public string Rating { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
    }
}
