using E_Comm.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_Comm.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class AuthorizeRoleAttribute : Attribute, IAsyncAuthorizationFilter
    {
        //public AuthorizeRoleAttribute(params object[] roles)
        //{
        //    //if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
        //    //    throw new ArgumentException("roles");
        //    //this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        //}
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(SessionHelper.GetObjectFromJson<string>(context.HttpContext.Session, "UserId")))
            {
                context.Result = new Microsoft.AspNetCore.Mvc.RedirectResult("/Account/Signup");
            }
            else
            {
                return;
            }
        }
    }
}
