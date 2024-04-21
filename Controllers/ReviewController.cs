using Microsoft.AspNetCore.Mvc;
using Nikimar.DTOs.Review;
using Nikimar.Models;
using Nikimar.Services.ReviewService;

namespace Nikimar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllAsync();
            return Ok(reviews);
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReviewById(int id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST: api/Review
        [HttpPost]
        public async Task<ActionResult<ReviewDto>> CreateReview([FromBody] ReviewCreateDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdReview = await _reviewService.CreateAsync(reviewDto);
            return Ok(createdReview);
        }

        // PUT: api/Review/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewCreateDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound($"No review found with ID {id}.");
            }

            await _reviewService.UpdateAsync(id, reviewDto);
            return NoContent();
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound($"No review found with ID {id}.");
            }

            await _reviewService.DeleteAsync(id);
            return NoContent();
        }

    }

}
