using Nikimar.DTOs;

namespace Nikimar.Services
{
    public interface IReviewService
    {
        Task<ReviewDto> AddReviewAsync(ReviewDto reviewDto);
    }
}
