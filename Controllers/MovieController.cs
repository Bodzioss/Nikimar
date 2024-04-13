using Microsoft.AspNetCore.Mvc;
using Nikimar.DTOs;
using Nikimar.Services;

namespace Nikimar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService; 

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}
