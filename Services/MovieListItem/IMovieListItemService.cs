using Nikimar.DTOs.MovieListItem;

namespace Nikimar.Services.MovieListItemService
{
    public interface IMovieListItemService
    {
        Task<MovieListItemDto> AddAsync(MovieListItemDto movieListItemDto);
        Task<MovieListItemDto> DeleteAsync(MovieListItemDto movieListItemDto);
    }
}
