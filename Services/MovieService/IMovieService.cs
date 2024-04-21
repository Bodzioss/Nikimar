using Nikimar.DTOs.Movie;

namespace Nikimar.Services.MovieService
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<MovieDto> GetByIdAsync(int id);
        Task<MovieCreateDto> CreateAsync(MovieCreateDto movieCreateDto);
        Task<MovieCreateDto> UpdateAsync(int id, MovieCreateDto movieCreateDto);
        Task DeleteAsync(int id);
    }
}
