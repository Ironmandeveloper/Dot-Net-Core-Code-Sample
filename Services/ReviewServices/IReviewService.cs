using DataModels.Models.Review;
using Dtos.ReviewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ReviewServices
{
    public interface IReviewService
    {
        Task<string> Create(Review review);
        Task<List<ReviewListDto>> Get(int ProductId);
        List<ReviewAdminListDto> GetReview();
        Task<string> Delete(int Id);
        Task<string> Update(Review review);

        Task<Review> GetReviewById(int ReviewId);
    }
}
