using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace E_Comm.Middlewares
{
    public class RedirectionMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404)
            {
                //Handle 404 page not found, maybe redirect it to custom 404 page or redirect it to homepage
                context.Response.Redirect("/");
            }
            else if (context.Response.StatusCode == 500)
            {
                //Handle 500 internal server error, maybe redirect it to custom 404 page or redirect it to homepage
                context.Response.Redirect("/");
            }
        }
    }
}