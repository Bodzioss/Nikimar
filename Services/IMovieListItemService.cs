using Nikimar.DTOs;

namespace Nikimar.Services
{
    public interface IMovieListItemService
    {
        Task AddAsync(MovieListItemDto movieListItemDto);
    }
}
