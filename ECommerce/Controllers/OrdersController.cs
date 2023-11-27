using Microsoft.AspNetCore.Mvc;
using Services.OrderServices;
using System.Threading.Tasks;

namespace E_Comm.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Pending()
        {
            return View(await _orderService.GetPendingOrders());
        }
    }
}
