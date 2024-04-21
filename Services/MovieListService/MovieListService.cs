using Microsoft.EntityFrameworkCore;
using Nikimar.DTOs.MovieList;
using Nikimar.DTOs.MovieListItem;
using Nikimar.Models;
namespace Nikimar.Services.MovieListService
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

        public async Task<MovieListCreateDto> CreateAsync(MovieListCreateDto movieListCreateDto, string userId)
        {
            var movieList = new MovieList
            {
                Name = movieListCreateDto.Name,
                UserId = userId  // Przypisanie listy do użytkownika
            };

            _context.MovieLists.Add(movieList);
            await _context.SaveChangesAsync();

            // Zwracanie DTO z zaktualizowanym identyfikatorem
            movieListCreateDto.Id = movieList.Id;
            return movieListCreateDto;
        }

        public async Task<MovieListDto> DeleteAsync(MovieListDto movieListDto)
        {
            var movieList = await _context.MovieLists.FindAsync(movieListDto.Id);
            if (movieList == null)
            {
                throw new InvalidOperationException("Movie list not found.");
            }

            _context.MovieLists.Remove(movieList);
            await _context.SaveChangesAsync();

            return movieListDto;
        }

        public async Task RemoveMovieFromListAsync(int movieListId, MovieListItemDto movieListItemDto)
        {
            var movieListItem = await _context.MovieListItems
                .FirstOrDefaultAsync(mli => mli.MovieListId == movieListId && mli.MovieId == movieListItemDto.MovieId);

            if (movieListItem == null)
            {
                throw new InvalidOperationException("Movie list item not found.");
            }

            _context.MovieListItems.Remove(movieListItem);
            await _context.SaveChangesAsync();
        }

        public async Task<MovieListDto> GetByIdAsync(int id)
        {
            // Przykład z użyciem Entity Framework
            var movieList = await _context.MovieLists
                .Where(ml => ml.Id == id)
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
                })
                .FirstOrDefaultAsync();

            return movieList;
        }

        public async Task<MovieListCreateDto> UpdateAsync(MovieListCreateDto movieListCreateDto)
        {
            // Znalezienie istniejącej listy filmów
            var movieList = await _context.MovieLists.FindAsync(movieListCreateDto.Id);
            if (movieList == null)
            {
                throw new KeyNotFoundException("Movie list not found.");
            }

            // Aktualizacja pól listy filmów
            movieList.Name = movieListCreateDto.Name;
            // Tutaj możesz dodać więcej pól do aktualizacji, zależnie od struktury twojego MovieListCreateDto i MovieList

            // Zapisanie zmian w bazie danych
            _context.MovieLists.Update(movieList);
            await _context.SaveChangesAsync();

            // Zwrócenie zaktualizowanego DTO
            return new MovieListCreateDto
            {
                Id = movieList.Id,
                Name = movieList.Name
            };
        }
    }

}
