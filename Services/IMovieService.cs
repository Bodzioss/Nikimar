using Nikimar.DTOs;

namespace Nikimar.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<MovieDto> GetByIdAsync(int id);
        Task<MovieDto> CreateAsync(MovieDto movieDto);
        Task UpdateAsync(MovieDto movieDto);
        Task DeleteAsync(int id);
    }
}
