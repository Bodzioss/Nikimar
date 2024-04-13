using Nikimar.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Nikimar.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<MovieDto> CreateAsync(MovieDto movieDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            var movies = await _context.Movies
                .Select(m => new MovieDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    ReleaseYear = m.ReleaseYear,
                    Genre = m.Genre
                })
                .ToListAsync();

            return movies;
        }

        public async Task<MovieDto> GetByIdAsync(int id)
        {
            var movie = await _context.Movies
                .Where(m => m.Id == id)
                .Select(m => new MovieDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    ReleaseYear = m.ReleaseYear,
                    Genre = m.Genre
                })
                .FirstOrDefaultAsync();

            return movie;
        }

        public Task UpdateAsync(MovieDto movieDto)
        {
            throw new NotImplementedException();
        }

        //TO DO
    }

}
