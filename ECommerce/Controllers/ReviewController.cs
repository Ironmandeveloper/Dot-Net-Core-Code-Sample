using DataModels.Models.Review;
using Dtos.ReviewDtos;
using E_Comm.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ReviewServices;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks; 

namespace E_Comm.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddReview(Review model)
        {
            model.CreatedOn = System.DateTime.Now;
            model.UpdatedOn = System.DateTime.Now;
            model.IsActive = false;
            model.IsDeleted = false;
            var response=await _reviewService.Create(model);
            return Json(new { isValid = true,message=response });
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(_reviewService.GetReview());
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(ReviewAddDto model)
        {
            if (model.Reviewid == 0)
            {

                await _reviewService.Create(new Review
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Reviews = model.Reviews,
                    Rating = model.Rating,
                });
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _reviewService.GetReview()) });
            }
            else
            {
                var review = await _reviewService.GetReviewById(model.Reviewid);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "AddOrEdit", review) });
            }
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int Reviewid)
        {
            var response = await _reviewService.Delete(Reviewid);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _reviewService.GetReview()) });
        }

        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int Reviewid, [Bind("Reviewid,IsActive,FirstName,LastName,Email,Rating,Reviews")] Review review)
        {
            if (review.Reviewid == 0)
            {
                return Json(new { message = "Id wasn't provided" });
            }
            else
            {
                review.UpdatedBy = GetLoggedUserId();
                review.UpdatedOn = DateTime.Now;
                var res = await _reviewService.Update(review);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _reviewService.GetReview()) });
            }
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
