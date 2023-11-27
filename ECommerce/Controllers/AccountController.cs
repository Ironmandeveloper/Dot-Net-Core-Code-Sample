using DataModels.DAL;
using DataModels.Models;
using Dtos.Account;
using E_Comm.Helpers;
using E_Comm.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.AnonymousUsersServices;
using Services.AuthServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Comm.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger _logger;
        public  readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession session;
        private readonly IAnonymousUsersService _anonymousUsersService;
        private readonly IAuthService _authService;
        //protected EncryptDecrypt encrypter = new EncryptDecrypt();
        public AccountController(IAnonymousUsersService anonymousUsersService, IAuthService authService,  IHttpContextAccessor httpContextAccessor, ILogger<AccountController> logger, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager)
        {
            _anonymousUsersService = anonymousUsersService;
           
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            this.session = httpContextAccessor.HttpContext.Session;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            this._roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        
        public async Task<IActionResult> Register()
        {
            var User = new IdentityUser
            {
                UserName = "admin@Ecommerce.com",
                Email = "admin@Ecommerce.com"
            };
            var result = await _userManager.CreateAsync(User, "Happy123*");
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(UserRole.Anonymous))
                    await _roleManager.CreateAsync(new IdentityRole(UserRole.Anonymous));
                if (await _roleManager.RoleExistsAsync(UserRole.Anonymous))
                {
                    await _userManager.AddToRoleAsync(User, UserRole.Anonymous);
                }
                return Ok("Registered successfully");
                //return View("RegistrationSuccess");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return Json(true);
        }
        [AllowAnonymous]
        public IActionResult Forgot_Password()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult emailTemp()
        {
            return View();
        }
        [HttpPost]
        //[Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        var userInRole = await _userManager.IsInRoleAsync(user, UserRoles.Admin);
                        if (userInRole)
                        {
                            HttpContext.Session.SetString("UserName", user.UserName);
                            HttpContext.Session.SetString("Email", user.Email);
                            HttpContext.Session.SetString("UserID", user.Id);
                            HttpContext.Session.SetString("RoleName", UserRoles.Admin);

                            var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, UserRoles.Admin),
                       new Claim("Email", user.Email)
                };
                            //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                            var principal = new ClaimsPrincipal(identity);
                            //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                            {
                                IsPersistent = model.RememberMe,
                                ExpiresUtc = DateTime.UtcNow.AddHours(2)
                            });

                        }
                        _logger.LogInformation("User logged in.");                       
                        return RedirectToAction("Index", "Admin");                       
                    }
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

                }
                catch (Exception ex)
                {
                    using (StreamWriter w = System.IO.File.AppendText("Product-Update.txt"))
                    {
                        Helpers.ExceptionHandler.Logger.Log("" + ex.Message.ToString(), w);
                    }
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    return View(model);
                }
            }
            return View(model);

        }
     
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                await _signInManager.SignOutAsync();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                _logger.LogInformation("User Logged out.");
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                using (StreamWriter w = System.IO.File.AppendText("Product-Update.txt"))
                {
                    Helpers.ExceptionHandler.Logger.Log("" + ex.Message.ToString(), w);
                }
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
