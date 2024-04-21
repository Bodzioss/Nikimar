using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nikimar.DTOs.Movie;
using Nikimar.Models;
using Nikimar.Services.MovieService;

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
        public async Task<ActionResult<MovieDto>> CreateMovie([FromBody] MovieCreateDto movieCreateDto)
        {
            // Sprawdzanie, czy przesłane dane są poprawne
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Tworzenie filmu za pomocą serwisu
                var createdMovieDto = await _movieService.CreateAsync(movieCreateDto);

                return Ok(createdMovieDto);
            }
            catch (Exception ex)
            {
                // Logowanie wyjątku i zwracanie odpowiedzi serwera
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDto>> UpdateMovie(int id, [FromBody] MovieCreateDto movieCreateDto)
        {
            // Sprawdzanie poprawności przesłanych danych
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var movieToUpdate = await _movieService.GetByIdAsync(id);
                if (movieToUpdate == null)
                {
                    return NotFound();
                }

                // Aktualizacja filmu za pomocą serwisu
                var updatedMovieDto = await _movieService.UpdateAsync(id, movieCreateDto);

                // Zwracanie zaktualizowanego filmu
                return Ok(updatedMovieDto);
            }
            catch (Exception ex)
            {
                // Logowanie wyjątku i zwracanie odpowiedzi serwera
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            try
            {
                var movieToDelete = await _movieService.GetByIdAsync(id);
                if (movieToDelete == null)
                {
                    return NotFound();
                }

                await _movieService.DeleteAsync(id);
                return NoContent(); // Zwraca status 204 No Content jako potwierdzenie usunięcia
            }
            catch (Exception ex)
            {
                // Logowanie wyjątku i zwracanie odpowiedzi serwera
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
