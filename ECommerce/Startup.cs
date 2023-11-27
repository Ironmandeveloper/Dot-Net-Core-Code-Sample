using DataModels.DAL;
using E_Comm.Configuration;
using E_Comm.Helpers.ProductTypes;
using E_Comm.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.AnonymousUsersServices;
using Services.AuthServices;
using Services.CartService;
using Services.EmailSenderService;
using Services.FaqServices;
using Services.FileHandlingServices;
using Services.OrderServices;
using Services.ProductServices;
using Services.ProductTypeServices;
using Services.ReviewServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystemNKU.Dtos.EmailDtos.MailRequests;
using static Services.EmailSenderService.IMailServices;

namespace E_Comm
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DbHandler.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddRazorPages();

            // Add services to the container.
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(x => x.LoginPath = "/Account/login");
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));
            services.AddRazorPages().AddRazorRuntimeCompilation();

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDBContext>(c => c.UseSqlServer(connectionString));
            //fetch mail configurations from appsettings.json
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.Configure<MyConfiguration>(Configuration.GetSection("myConfiguration"));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();
            //AuthServices start here
            services.AddTransient<IAuthService, AuthService>();

            //custom cms services starts here
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IFileHandlingService, FileHandlingService>();
            services.AddTransient<IFaqService, ChatService>();
            services.AddTransient<IAnonymousUsersService, AnonymousUsersService>();
            services.AddTransient<IReviewService, ReviewService>();
            //cms services ends here

            //custom web services starts here
            services.AddTransient<IOrderService, OrderService>();
            //cuctom web services ends here



            //Email sender Services starts here
            services.AddTransient<IMailService, MailService>();
            //Email sender Services ends here
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
          .AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(origin => true) // allow any origin
          .AllowCredentials()); // allow credentials

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware<RedirectionMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
