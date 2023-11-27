using DataModels.Models.Cart;
using Dtos.Product;
using E_Comm.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.CartService;
using Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Comm.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService productService;
        public CartController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            var userId = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "UserId");
            int USERID = Convert.ToInt32(userId);
            if (id == null)
            {
                return Redirect("/Cart/Index?userId=" + Convert.ToInt32(userId));
            }
            var productObj = productService.GetProductById(id);
            return Redirect("/Cart/Index?userId=" + Convert.ToInt32(userId));
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            return View(cart);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult UpdateCart([FromBody]IEnumerable<UpdateCartDto> cartDto)
        {
            var list = new List<UpdateCartDto>();
            foreach(var j in cartDto)
            {
                list.Add(j);
            }
            List<Cart> myCart = new List<Cart>();
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            for (int i=0; i< list.Count(); i++)
            {
                Cart obj = new Cart();
                if (list[i].CartId == cart[i].CartId)
                {
                    obj.ProductCount = list[i].Quantity;
                    obj.ProductId = cart[i].ProductId;
                    obj.CartId = cart[i].CartId;
                    obj.Price = cart[i].Price;
                    obj.Image = cart[i].Image;
                    obj.Name = cart[i].Name;
                    myCart.Add(obj);
                }
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", myCart);
            var cart1 = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewCart", cart1) });
        }
        private int isExist(int id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult AddToCart(int Id,string qty)
        {
            var userId = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "UserId");
            var productObj = productService.GetProductById(Id);
            Cart productModel = new Cart();
            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart {CartId=Id,Image=productObj.Image,Name=productObj.Name,Price=Convert.ToInt32(productObj.Price),ProductId=Id, ProductCount = Convert.ToInt32(qty)});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                int index = isExist(Id);
                if (index != -1)
                {
                    cart[index].ProductCount= cart[index].ProductCount+Convert.ToInt32(qty);
                }
                else
                {
                    cart.Add(new Cart { CartId = Id, Image = productObj.Image, Name = productObj.Name, Price = Convert.ToInt32(productObj.Price), ProductId = Id, ProductCount = Convert.ToInt32(qty) });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return Ok();
        }
        public IActionResult AddToCartSolo(int Id, int count)
        {
            var productObj = productService.GetProductById(Id);
            var userId = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "UserId");

            return Ok();
        }
      
        public IActionResult RemoveFromCart(int id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            var cart1 = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewCart", cart1) });

        }
    }
}
