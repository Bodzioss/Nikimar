using Microsoft.AspNetCore.Mvc;
using Nikimar.DTOs.MovieList;
using Nikimar.DTOs.MovieListItem;
using Nikimar.Models;
using Nikimar.Services.MovieListService;
using System.Security.Claims;

namespace Nikimar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieListController : ControllerBase
    {
        private readonly IMovieListService _movieListService;

        public MovieListController(IMovieListService movieListService)
        {
            _movieListService = movieListService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieListDto>>> GetAllMovieLists()
        {
            var movieLists = await _movieListService.GetAllAsync();
            return Ok(movieLists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieListDto>> GetMovieListById(int id)
        {
            try
            {
                var movieList = await _movieListService.GetByIdAsync(id);
                if (movieList == null)
                {
                    return NotFound($"No movie list found with ID {id}.");
                }

                return Ok(movieList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<MovieListDto>> CreateMovieList([FromBody] MovieListCreateDto movieListCreateDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in.");
            }

            var createdMovieList = await _movieListService.CreateAsync(movieListCreateDto, userId);
            return CreatedAtAction("GetAllMovieLists", new { id = createdMovieList.Id }, createdMovieList);
        }

        [HttpPost("{movieListId}/movies")]
        public async Task<IActionResult> AddMovieToList(int movieListId, [FromBody] MovieListItemDto movieListItemDto)
        {
            await _movieListService.AddMovieToListAsync(movieListId, movieListItemDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieListDto>> UpdateMovieList(int id, [FromBody] MovieListCreateDto movieListCreateDto)
        {

            try
            {
                var updatedMovieList = await _movieListService.UpdateAsync(movieListCreateDto);
                if (updatedMovieList == null)
                {
                    return NotFound($"No movie list found with ID {id}.");
                }

                return Ok(updatedMovieList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieList(int id)
        {
            try
            {
                var movieListToDelete = await _movieListService.GetByIdAsync(id);
                if (movieListToDelete == null)
                {
                    return NotFound($"No movie list found with ID {id}.");
                }

                await _movieListService.DeleteAsync(movieListToDelete);
                return NoContent();  // HTTP 204 No Content jako potwierdzenie usunięcia
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
