using Nikimar.DTOs;

namespace Nikimar.Services
{
    public interface IMovieListItemService
    {
        Task<MovieListItemDto> AddAsync(MovieListItemDto movieListItemDto);
        Task<MovieListItemDto> DeleteAsync(MovieListItemDto movieListItemDto);
    }
}
