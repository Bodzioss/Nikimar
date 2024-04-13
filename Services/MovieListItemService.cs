using Nikimar.DTOs;

namespace Nikimar.Services
{
    public class MovieListItemService : IMovieListItemService
    {
        private readonly ApplicationDbContext _context;

        public MovieListItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MovieListItemDto movieListItemDto)
        {
            var movieListItem = new MovieListItem
            {
                MovieListId = movieListItemDto.MovieListId,
                MovieId = movieListItemDto.MovieId
            };

            _context.MovieListItems.Add(movieListItem);
            await _context.SaveChangesAsync();
        }

    }
}
