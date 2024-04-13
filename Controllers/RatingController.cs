using Microsoft.AspNetCore.Mvc;
using Nikimar.DTOs;
using Nikimar.Services;

namespace Nikimar.Controllers
{
    [Route("api/movies/{movieId}/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<ActionResult<RatingDto>> AddRating(int movieId, [FromBody] RatingDto ratingDto)
        {
            ratingDto.MovieId = movieId; 
            var createdRating = await _ratingService.AddRatingAsync(ratingDto);
            return CreatedAtAction("AddRating", new { movieId = movieId, id = createdRating.Id }, createdRating);
        }
    }

}
