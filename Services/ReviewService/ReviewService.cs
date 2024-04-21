using Microsoft.EntityFrameworkCore;
using Nikimar.DTOs.Review;
using Nikimar.Models;

namespace Nikimar.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewCreateDto> CreateAsync(ReviewCreateDto reviewDto)
        {
            var review = new Review
            {
                Content = reviewDto.Content,
                Rating = reviewDto.Rating,
                UserId = reviewDto.UserId,
                MovieId = reviewDto.MovieId
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return new ReviewCreateDto
            {
                Content = review.Content,
                Rating = review.Rating,
                UserId = review.UserId,
                MovieId = review.MovieId
            };
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                throw new KeyNotFoundException("Review not found.");
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReviewDto>> GetAllAsync()
        {
            return await _context.Reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Content = r.Content,
                Rating = r.Rating,
                UserId = r.UserId,
                MovieId = r.MovieId
            }).ToListAsync();
        }

        public async Task<ReviewDto> GetByIdAsync(int id)
        {
            var review = await _context.Reviews
                .Where(r => r.Id == id)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Content = r.Content,
                    Rating = r.Rating,
                    UserId = r.UserId,
                    MovieId = r.MovieId
                }).FirstOrDefaultAsync();

            if (review == null)
            {
                throw new KeyNotFoundException("Review not found.");
            }

            return review;
        }

        public async Task<ReviewCreateDto> UpdateAsync(int id, ReviewCreateDto reviewDto)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                throw new KeyNotFoundException("Review not found.");
            }

            review.Content = reviewDto.Content;
            review.Rating = reviewDto.Rating;
            review.UserId = reviewDto.UserId;
            review.MovieId = reviewDto.MovieId;

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            return new ReviewCreateDto
            {
                Content = review.Content,
                Rating = review.Rating,
                UserId = review.UserId,
                MovieId = review.MovieId
            };
        }
    }

}
