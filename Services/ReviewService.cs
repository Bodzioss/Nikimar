using Nikimar.DTOs;
using Nikimar.Models;

namespace Nikimar.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewDto> AddReviewAsync(ReviewDto reviewDto)
        {
            var review = new Review
            {
                MovieId = reviewDto.MovieId,
                Content = reviewDto.Content,
                DatePosted = DateTime.Now,
                UserId = reviewDto.UserId 
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return reviewDto; 
        }
    }

}
