using Nikimar.DTOs;

namespace Nikimar.Services
{
    public interface IMovieListService
    {
        Task<IEnumerable<MovieListDto>> GetAllAsync();
        Task<MovieListDto> CreateAsync(MovieListDto movieListDto, string userId);
        Task<MovieListDto> DeleteAsync(MovieListDto movieListDto);
        Task AddMovieToListAsync(int movieListId, MovieListItemDto movieListItemDto);
        Task RemoveMovieFromListAsync(int movieListId, MovieListItemDto movieListItemDto);
    }

}
