using Microsoft.AspNetCore.Mvc;
using Services.ProductServices;

namespace E_Comm.Controllers
{
    public class LandingController : Controller
    {
        private readonly IProductService _productService;
        public LandingController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetTop8Products());
        }
    }
}
