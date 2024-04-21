using Nikimar.DTOs.MovieList;
using Nikimar.DTOs.MovieListItem;

namespace Nikimar.Services.MovieListService
{
    public interface IMovieListService
    {
        Task<IEnumerable<MovieListDto>> GetAllAsync();
        Task<MovieListCreateDto> CreateAsync(MovieListCreateDto movieListCreateDto, string userId);
        Task<MovieListDto> DeleteAsync(MovieListDto movieListDto);
        Task AddMovieToListAsync(int movieListId, MovieListItemDto movieListItemDto);
        Task RemoveMovieFromListAsync(int movieListId, MovieListItemDto movieListItemDto);
        Task<MovieListCreateDto> UpdateAsync(MovieListCreateDto movieListCreateDto);
        Task<MovieListDto> GetByIdAsync(int id);
    }

}
