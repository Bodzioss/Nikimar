using Microsoft.EntityFrameworkCore;
using Nikimar.DTOs.Rating;
using Nikimar.Models;

namespace Nikimar.Services.RatingService
{
    public class RatingService : IRatingService
    {
        private readonly ApplicationDbContext _context;

        public RatingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RatingCreateDto> CreateAsync(RatingCreateDto ratingCreateDto)
        {
            var rating = new Rating
            {
                MovieId = ratingCreateDto.MovieId,
                Value = ratingCreateDto.Value,
                UserId = ratingCreateDto.UserId
            };

            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();

            return ratingCreateDto;
        }

        public async Task DeleteAsync(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                throw new KeyNotFoundException("Rating not found.");
            }

            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RatingDto>> GetAllAsync()
        {
            return await _context.Ratings
                .Select(rating => new RatingDto
                {
                    Id = rating.Id,
                    UserId = rating.UserId,
                    Value = rating.Value,
                    MovieId = rating.MovieId
                })
                .ToListAsync();
        }

        public async Task<RatingDto> GetByIdAsync(int id)
        {
            var rating = await _context.Ratings
                .Where(r => r.Id == id)
                .Select(r => new RatingDto
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    Value = r.Value,
                    MovieId = r.MovieId
                })
                .FirstOrDefaultAsync();

            return rating;
        }

        public async Task<RatingDto> UpdateAsync(int id, RatingCreateDto ratingCreateDto)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                throw new KeyNotFoundException("Rating not found.");
            }

            rating.UserId = ratingCreateDto.UserId;
            rating.Value = ratingCreateDto.Value;
            rating.MovieId = ratingCreateDto.MovieId;

            _context.Ratings.Update(rating);
            await _context.SaveChangesAsync();

            return new RatingDto
            {
                Id = rating.Id,
                UserId = rating.UserId,
                Value = rating.Value,
                MovieId = rating.MovieId
            };
        }
    }
}
