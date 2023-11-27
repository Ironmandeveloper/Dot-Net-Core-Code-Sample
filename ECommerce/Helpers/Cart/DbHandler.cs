using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Comm.Helpers.Cart
{
    public class DbHandler
    {

        public static int GetCartCount()
        {
            //var cart = SessionHelper.GetObjectFromJson<List<DataModels.Models.Cart.Cart>>(_httpContextAccessor.HttpContext.Session, "cart");
            //if(cart.Count() > 0)
            //{
            //    return cart.Count();
            //}
            return 0;
        }

    }
}
