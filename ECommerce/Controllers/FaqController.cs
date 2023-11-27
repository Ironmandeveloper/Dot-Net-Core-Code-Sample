using DataModels.Models;
using DataModels.Models.Faq;
using Dtos.Faq;
using E_Comm.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.FaqServices;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace E_Comm.Controllers
{
    [Authorize]
    public class FaqController : Controller
    {
        private readonly IFaqService _faqService;
        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _faqService.GetFaqs());
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AlreadyExists(string Question)
        {
            if (await _faqService.AlreadyExists(Question))
            {
                return Json(new { message = "Already exists" });
            }
            else
            {
                return Json(new { message = "Does not exists" });
            }
        }
       
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Question,Answer,IsActive")] Faq faq)
        {
            if (faq.Id == 0)
            {
                return Json(new { message = "Id wasn't provided" });
            }
            else
            {
                faq.UpdatedBy = GetLoggedUserId();
                faq.UpdatedOn = DateTime.Now;
                await _faqService.Update(faq);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _faqService.GetFaqs()) });
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(FaqDto model)
        {
            if (model.Id == 0)
            {
                await _faqService.Create(new Faq
                {
                    IsActive = model.IsActive,
                    Question= model.Question,
                    Answer= model.Answer,
                    CreatedBy = GetLoggedUserId(),
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    UpdatedBy = GetLoggedUserId(),
                    UpdatedOn = DateTime.Now
                });
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _faqService.GetFaqs()) });
            }
            else
            {
                var Faq = await _faqService.GetFaqById(model.Id);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "AddOrEdit", Faq) });
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _faqService.Delete(Id);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _faqService.GetFaqs()) });
        }
        public string GetLoggedUserId()
        {
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Identities.First().Claims.ElementAt(0).Value.ToString();

            return userId;
        }
    }
}
