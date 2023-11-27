using DataModels.Models.Cart;
using DataModels.Models.Order;
using Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetPendingOrders();
        Task<string> Create(List<Cart> order);
    }
}
