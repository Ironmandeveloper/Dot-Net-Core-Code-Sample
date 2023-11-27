using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Comm.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        
        [Authorize]
        [Route("/Account/Administrator")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Orders()
        {
            return View();
        }
    }
}
