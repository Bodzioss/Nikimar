using Microsoft.AspNetCore.Mvc;
using Nikimar.DTOs;
using Nikimar.Services;

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

        [HttpPost]
        public async Task<ActionResult<MovieListDto>> CreateMovieList([FromBody] MovieListDto movieListDto)
        {
            var createdMovieList = await _movieListService.CreateAsync(movieListDto);
            return CreatedAtAction("GetAllMovieLists", new { id = createdMovieList.Id }, createdMovieList);
        }

        [HttpPost("{movieListId}/movies")]
        public async Task<IActionResult> AddMovieToList(int movieListId, [FromBody] MovieListItemDto movieListItemDto)
        {
            await _movieListService.AddMovieToListAsync(movieListId, movieListItemDto);
            return Ok();
        }
    }

}
