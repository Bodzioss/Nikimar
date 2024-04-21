using Nikimar.DTOs.Review;

namespace Nikimar.Services.ReviewService
{
    public interface IReviewService
    {
        Task<ReviewCreateDto> CreateAsync(ReviewCreateDto reviewDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ReviewDto>> GetAllAsync();
        Task<ReviewDto> GetByIdAsync(int id);
        Task<ReviewCreateDto> UpdateAsync(int id, ReviewCreateDto reviewDto);
    }
}
