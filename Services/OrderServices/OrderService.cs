using DataModels.DAL;
using DataModels.Models.Cart;
using DataModels.Models.Order;
using Dtos.CartDtos;
using Dtos.OrderDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDBContext _context;
        public OrderService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(List<Cart> order)
        {
            foreach (var item in order)
            {
                
                    try
                    {
                        Order obj = new Order();
                        obj.ProductName=item.Name;
                        obj.Price = item.Price;
                        obj.Quantity = item.ProductCount;
                        obj.UpdatedOn = DateTime.Now;
                        obj.CreatedOn = DateTime.Now;
                        obj.Status = "Pending";
                        obj.CreatedBy = "";
                        obj.UpdatedBy = "";
                        obj.IsActive = true;
                        obj.IsDeleted = false;
                        await _context.AddAsync(obj);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception) { throw; }
              
            }
            return "saved successfully";
        }

        public async Task<List<OrderDto>> GetPendingOrders()
        {
            var PendingOrders = await _context.Orders.Where(x=>x.Status.Equals("Pending")).Select(x => new OrderDto
            {
                Total = x.Quantity * x.Price,
                Status="Pending",
                Address="N-A",
                PhoneNumber="N-A",
                ProductName=x.ProductName,
                PurchaseDate=x.CreatedOn,
            }).ToListAsync();
            if (PendingOrders.Count() > 0)
            {
                return PendingOrders;
            }
            return new List<OrderDto>();
        }        
    }
}
