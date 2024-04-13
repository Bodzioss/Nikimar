using Microsoft.EntityFrameworkCore;
using Nikimar.DTOs;
using Nikimar.Models;

namespace Nikimar.Services
{
    public class MovieListService : IMovieListService
    {
        private readonly ApplicationDbContext _context;

        public MovieListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieListDto>> GetAllAsync()
        {
            var movieLists = await _context.MovieLists
                .Select(ml => new MovieListDto
                {
                    Id = ml.Id,
                    Name = ml.Name,
                    Items = ml.Items.Select(i => new MovieListItemDto
                    {
                        MovieId = i.MovieId,
                        MovieListId = i.MovieListId
                        // TO DO
                    }).ToList()
                }).ToListAsync();

            return movieLists;
        }

        public async Task<MovieListDto> CreateAsync(MovieListDto movieListDto)
        {
            var movieList = new MovieList
            {
                Name = movieListDto.Name,
                //TO DO
            };

            _context.MovieLists.Add(movieList);
            await _context.SaveChangesAsync();

            movieListDto.Id = movieList.Id; 
            return movieListDto;
        }

        public async Task AddMovieToListAsync(int movieListId, MovieListItemDto movieListItemDto)
        {
            var movieListItem = new MovieListItem
            {
                MovieListId = movieListId,
                MovieId = movieListItemDto.MovieId,
                //TO DO
            };

            _context.MovieListItems.Add(movieListItem);
            await _context.SaveChangesAsync();
        }
    }

}
