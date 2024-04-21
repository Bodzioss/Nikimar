using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nikimar.DTOs;
using Nikimar.Models;
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

        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovie([FromBody] MovieDto movieDto)
        {
            // Sprawdzanie, czy przesłane dane są poprawne
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Tworzenie filmu za pomocą serwisu
                var createdMovieDto = await _movieService.CreateAsync(movieDto);

                // Zwracanie odpowiedzi z lokalizacją nowo utworzonego zasobu
                return CreatedAtAction(nameof(GetMovie), new { id = createdMovieDto.Id }, createdMovieDto);
            }
            catch (Exception ex)
            {
                // Logowanie wyjątku i zwracanie odpowiedzi serwera
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
