using Nikimar.DTOs;

namespace Nikimar.Services
{
    public interface IRatingService
    {
        Task<RatingDto> AddRatingAsync(RatingDto ratingDto);
    }
}
