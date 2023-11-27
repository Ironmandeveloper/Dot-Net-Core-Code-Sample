using DataModels.DAL;
using DataModels.Models.Cart;
using Dtos.CartDtos;
using Dtos.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ApplicationDBContext context;
        public CartService(ApplicationDBContext context)
        {
            this.context = context;
        }
        //public async Task<string> AddToCart(ProductEditDto productObj,int userId)
        //{
        //    Cart obj = new Cart();
        //    obj.ProductId = productObj.Id;
        //    obj.Image = productObj.Image;
        //    obj.Price = Convert.ToInt32(productObj.Price);
        //    obj.Name = productObj.Name;
        //    int count = await context.Cart.Where(x => x.ProductId.Equals(productObj.Id)&&x.userId.Equals(userId)).CountAsync();
        //    if (count == 0)
        //    {
        //        obj.ProductCount = 1;
        //        obj.userId = userId;
        //        await context.Cart.AddAsync(obj);
        //        await context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        var cartData = await context.Cart.Where(x => x.ProductId.Equals(productObj.Id) && x.userId.Equals(userId)).FirstOrDefaultAsync();
        //        cartData.ProductCount = cartData.ProductCount + 1;
        //        obj.userId = userId;
        //        context.Cart.Update(cartData);
        //        context.SaveChanges();

        //    }
        //    return "Product has been added to cart";
        //}

        //public async Task<string> AddToCartSolo(ProductEditDto productObj, int count,int userId)
        //{
        //    Cart obj = new();
        //    obj.ProductId = productObj.Id;
        //    obj.Image = productObj.Image;
        //    obj.Price = Convert.ToInt32(productObj.Price);
        //    obj.Name = productObj.Name;
        //    List<Cart> cartByProductId = this.GetCartDataByProductId(productObj.Id);
        //    if (cartByProductId.Count == 0)
        //    {
        //        obj.ProductCount = count;
        //        obj.userId = userId;
        //        await context.Cart.AddAsync(obj);
        //        await context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        var cartData = context.Cart.Where(x => x.ProductId == productObj.Id).FirstOrDefault();
        //        cartData.ProductCount = cartData.ProductCount + count;
        //        obj.userId = userId;
        //        context.Cart.Update(cartData);
        //        context.SaveChanges();

        //    }
        //    return "Product has been added to cart";
        //}

        //public List<Cart> GetCartDataByProductId(int pId)
        //{
        //    var cartData = (from data in context.Cart where data.ProductId == pId select data).ToList();
        //    return cartData;
        //}

        //public List<Cart> GetAllCartData()
        //{
        //    var cartData = (from data in context.Cart select data).ToList();
        //    return cartData;
        //}
        //public async Task<string> UpdateCart(IEnumerable<UpdateCartDto> cartDto, int userId)
        //{
        //    foreach (var item in cartDto)
        //    {
        //        var obj = await context.Cart.Where(x => x.CartId.Equals(item.CartId)).FirstOrDefaultAsync();
        //        if (obj != null)
        //        {
        //            obj.ProductCount = item.Quantity;
        //            obj.userId = userId;
        //            context.Cart.Update(obj);
        //            await context.SaveChangesAsync();
        //        }
        //    }
        //    return "cart has been updated successfully";
        //}
        //public async Task<string> RemoveFromCart(int CartId, int userid)
        //{
        //    var order = await context.Orders.Where(x => x.CartId.Equals(CartId)).FirstOrDefaultAsync();
        //    if (order != null)
        //    {
        //        context.Orders.Remove(order);
        //        await context.SaveChangesAsync();
        //    }
        //    var cart =await context.Cart.Where(x => x.CartId.Equals(CartId)&&x.userId==userid).FirstOrDefaultAsync();
        //    if (cart != null)
        //    {
        //        context.Cart.Remove(cart);
        //        await context.SaveChangesAsync();
        //        return "cart has been removed successfully";
        //    }
        //    else
        //    {
        //        return "cart doesn't exists";
        //    }
        //}

        //public List<CartDto> FetchCartDataByUserID(int Id)
        //{
        //    var Order = (from c in context.Cart
        //                   join u in context.AnonymousUsers on c.userId equals u.Id
        //                   where (u.Id == Id)
        //                   select new CartDto
        //                   {
        //                       CartId = c.CartId,
        //                       ProductName=c.Name,
        //                       Quantity=c.ProductCount,
        //                       Total=c.Price*c.ProductCount,
        //                   }).ToList();
        //    if (Order.Count() > 0)
        //    {
        //        return Order;
        //    }
        //    return new List<CartDto>();
        //}

        //public List<Cart> FetchCartsListByUserID(int userId)
        //{
        //    var CartList = (from c in context.Cart
        //                join u in context.AnonymousUsers on c.userId equals u.Id
        //                where (u.Id == userId)
        //                select new Cart
        //                {
        //                    CartId = c.CartId,
        //                    Name = c.Name,
        //                    ProductCount = c.ProductCount,
        //                    ProductId=c.ProductId,
        //                    Image=c.Image,
        //                    Price=c.Price,
        //                    userId=c.userId,
        //                }).ToList();
        //    if (CartList.Count() > 0)
        //    {
        //        return CartList;
        //    }
        //    return new List<Cart>();
        //}
    }
}
