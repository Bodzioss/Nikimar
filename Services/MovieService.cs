using Nikimar.DTOs;
using Microsoft.EntityFrameworkCore;
using Nikimar.Models;

namespace Nikimar.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieDto> CreateAsync(MovieDto movieDto)
        {
            // Przekształcanie MovieDto do Movie
            var movie = new Movie
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                ReleaseYear = movieDto.ReleaseYear,
                Genre = movieDto.Genre
            };

            // Dodawanie nowego filmu do kontekstu bazy danych
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            // Uaktualnienie MovieDto z przypisanym Id z bazy danych
            movieDto.Id = movie.Id;
            return movieDto;
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new InvalidOperationException("Movie not found.");
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
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

        public async Task UpdateAsync(MovieDto movieDto)
        {
            // Znajdź film w bazie danych
            var movie = await _context.Movies.FindAsync(movieDto.Id);
            if (movie == null)
            {
                throw new InvalidOperationException("Movie not found.");
            }

            // Aktualizuj właściwości filmu
            movie.Title = movieDto.Title;
            movie.Description = movieDto.Description;
            movie.ReleaseYear = movieDto.ReleaseYear;
            movie.Genre = movieDto.Genre;

            // Zapisz zmiany w bazie danych
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
    }

}
