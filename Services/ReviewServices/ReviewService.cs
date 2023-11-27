using DataModels.DAL;
using DataModels.Models.Review;
using Dtos.ReviewDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDBContext _context;
        public ReviewService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<string> Create(Review review)
        {
            await _context.Review.AddAsync(review);
            await _context.SaveChangesAsync();
            return "Review has been added successfully";
        }

        public async Task<List<ReviewListDto>> Get(int ProducId)
        {
            var Reviews = await _context.Review.Where(x => x.ProductId.Equals(ProducId) && x.IsActive.Equals(true)).Select(x => new ReviewListDto
            {
                FullName = x.FirstName + " " + x.LastName,
                Rating = x.Rating,
                Review = x.Reviews
            }).ToListAsync();
            if (Reviews.Any())
            {
                return Reviews;
            }
            return new List<ReviewListDto>();
        }
        public List<ReviewAdminListDto> GetReview()
        {
            var Reviews = (from r in _context.Review
                           join p in _context.Products on r.ProductId equals p.Id
                           select new ReviewAdminListDto
                           {
                               Email = r.Email,
                               FullName = r.FirstName+" "+r.LastName,
                               ProductId =r.ProductId ,
                               ProductName= p.Name,
                               Rating = r.Rating,
                               Reviews = r.Reviews,
                               Reviewid = r.Reviewid,
                               IsActive=r.IsActive
                           }).ToList();
            return Reviews;
        }

        public async Task<string> Delete(int Id)
        {
            try
            {
                var productType = await _context.Review.Where(x => x.Reviewid.Equals(Id)).FirstOrDefaultAsync();
                if (productType == null)
                {
                    return "Review doesn't exists";
                }
                _context.Review.Remove(productType);
                await _context.SaveChangesAsync();
                return "Review has been deleted Successfully";
            }
            catch (Exception) { throw; }
        }


        public async Task<string> Update(Review review)
        {

            var reviews = await _context.Review.Where(x => x.Reviewid == review.Reviewid).FirstOrDefaultAsync();
            if (reviews == null)
            {
                return "Review doesn't exists";
            }
            reviews.FirstName = review.FirstName;
            reviews.LastName = review.LastName;
            reviews.Email = review.Email;
            reviews.Rating = review.Rating;
            reviews.Reviews = review.Reviews;
            reviews.IsActive = review.IsActive;
            _context.Review.Update(reviews);
            await _context.SaveChangesAsync();
            return "Review has been updated successfully";
        }

        public async Task<Review> GetReviewById(int reviewId)
        {
            var review = await _context.Review.Where(r => r.Reviewid == reviewId).FirstOrDefaultAsync();
            if (reviewId == null)
            {
                return new Review();
            }
            else
            {
                return review;
            }
        }
    }
}
