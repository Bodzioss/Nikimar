using Microsoft.AspNetCore.Mvc;
using Nikimar.DTOs.Rating;
using Nikimar.Models;
using Nikimar.Services.RatingService;

namespace Nikimar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllAsync();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RatingDto>> GetRatingById(int id)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult<RatingCreateDto>> CreateRating([FromBody] RatingCreateDto ratingCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRating = await _ratingService.CreateAsync(ratingCreateDto);
            return Ok(createdRating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] RatingCreateDto ratingCreateDto)
        {
            try
            {
                var updatedRating = await _ratingService.UpdateAsync(id, ratingCreateDto);
                if (updatedRating == null)
                {
                    return NotFound($"No rating found with ID {id}.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            try
            {
                var rating = await _ratingService.GetByIdAsync(id);
                if (rating == null)
                {
                    return NotFound($"No rating found with ID {id}.");
                }

                await _ratingService.DeleteAsync(id);
                return NoContent(); // Status 204 No Content to confirm deletion
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
