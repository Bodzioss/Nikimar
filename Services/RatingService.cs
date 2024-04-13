using Nikimar.DTOs;
using Nikimar.Models;

namespace Nikimar.Services
{
    public class RatingService : IRatingService
    {
        private readonly ApplicationDbContext _context; 

        public RatingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RatingDto> AddRatingAsync(RatingDto ratingDto)
        {
            var rating = new Rating
            {
                MovieId = ratingDto.MovieId,
                Value = ratingDto.Value,
                UserId = ratingDto.UserId 
            };

            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();

            return ratingDto; 
        }
    }
}
