using Nikimar.DTOs;

namespace Nikimar.Services
{
    public interface IMovieListService
    {
        Task<IEnumerable<MovieListDto>> GetAllAsync();
        Task<MovieListDto> CreateAsync(MovieListDto movieListDto);
        Task AddMovieToListAsync(int movieListId, MovieListItemDto movieListItemDto);
    }

}
