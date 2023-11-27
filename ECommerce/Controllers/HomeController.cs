using Dtos.EmailDtos.MailRequests;
using Dtos.Faq;
using Dtos.Product;
using E_Comm.Configuration;
using E_Comm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Services.EmailSenderService;
using Services.FaqServices;
using Services.ProductServices;
using Services.ReviewServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Services.EmailSenderService.IMailServices;

namespace E_Comm.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyConfiguration _myConfiguration;
        private readonly ILogger<HomeController> _logger;
        public readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IMailService _mailService;
        private readonly ISession session;
        private readonly IProductService productsService;
        private readonly IReviewService _reviewService;
        private readonly IFaqService _faqService;
        public HomeController(IMailService mailService, ILogger<HomeController> logger, IReviewService reviewService, IFaqService faqService, IHttpContextAccessor httpContextAccessor, IOptions<MyConfiguration> myConfiguration, IProductService productsService)
        {
            _reviewService = reviewService;
            _logger = logger; 
            _faqService = faqService;
            _mailService = mailService;
            _myConfiguration = myConfiguration.Value;
            this.session = httpContextAccessor.HttpContext.Session;
            this.productsService = productsService;
        }
        public IActionResult Index()
        {
            return View(productsService.GetTop8Products());
        }
        [HttpGet("/{name}")]
        public async Task<IActionResult> Index1(string name)
        {
            try
            {
                var model = new ProductDetialVm();

                model.Faq = _faqService.GetFaqs().Result.Select(x => new FaqDto
                {
                    Question = x.Question,
                    Answer = x.Answer
                }).ToList();

                model.productDet =await productsService.GetProductByName(name);
                model.ReviewListDtos = await _reviewService.Get(model.productDet.Id);
                model.model = await productsService.FetchProductByTypeName(name);
                if(model.model.Count()==0)
                {
                    Response.Redirect("/");
                }
                return View(model);
            }catch(Exception ex)
            {
                using (StreamWriter w = System.IO.File.AppendText("Product-Update.txt"))
                {
                    Helpers.ExceptionHandler.Logger.Log("" + ex.InnerException.Message.ToString(), w);
                }
                return View(new ProductDetialVm()); }
        }
        public IActionResult Checkout()
        {
            return View();
        }
 
        public IActionResult About()
        {
            this.session.SetString("ProjectEndPoint",_myConfiguration.EndPoint);
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactUs contact)
        {
            try
            {
                var webRoot = _hostingEnvironment.WebRootPath;
                var pathToFile = _hostingEnvironment.WebRootPath
                + Path.DirectorySeparatorChar.ToString()
                + "lib"
                + Path.DirectorySeparatorChar.ToString()
                + "emailTemp"
                + Path.DirectorySeparatorChar.ToString()
                + "Contact.html";
                var builder = new BodyBuilder(); 

                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();

                }
                string messageBody = string.Format(builder.HtmlBody,
                  contact.fname,
                  contact.lname,
                  contact.Subject,
                  contact.Email,
                  contact.Message

                );
                MailRequest request = new MailRequest();
                request.Subject = "Med Ambian - Contact us";
                request.ToEmail = contact.Email;
                request.Body = messageBody;

                Task.Run(() => //This code runs on a new thread, control is returned to the caller on the UI thread.
                {
                    _mailService.SendEmailAsync(request);
                });
            }
            catch (Exception ex)
            {
                using (StreamWriter w = System.IO.File.AppendText("Product-Update.txt"))
                {
                    Helpers.ExceptionHandler.Logger.Log("" + ex.Message.ToString(), w);
                }
                return Json(new { isValid = true, message = "Email has been sent successfully" });
            }
            return Json(new { isValid = true, message = "Email has been sent successfully" });
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}