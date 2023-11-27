using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ReviewDtos
{
    public class ReviewAddDto
    {
        public int Reviewid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Reviews { get; set; }
        public string Rating { get; set; }
    }
}
