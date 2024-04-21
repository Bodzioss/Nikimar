using Nikimar.DTOs;
using Nikimar.Models;

namespace Nikimar.Services
{
    public class MovieListItemService : IMovieListItemService
    {
        private readonly ApplicationDbContext _context;

        public MovieListItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieListItemDto> AddAsync(MovieListItemDto movieListItemDto)
        {
            var movieListItem = new MovieListItem
            {
                MovieListId = movieListItemDto.MovieListId,
                MovieId = movieListItemDto.MovieId
            };

            _context.MovieListItems.Add(movieListItem);
            await _context.SaveChangesAsync();

            return movieListItemDto;
        }

        public async Task<MovieListItemDto> DeleteAsync(MovieListItemDto movieListItemDto)
        {
            var movieListItem = await _context.MovieListItems.FindAsync(movieListItemDto.Id);

            if (movieListItem == null)
            {
                throw new InvalidOperationException("Movie list item not found.");
            }

            _context.MovieListItems.Remove(movieListItem);
            await _context.SaveChangesAsync();

            return movieListItemDto;
        }

    }
}
