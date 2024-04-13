using Microsoft.AspNetCore.Mvc;
using Nikimar.DTOs;
using Nikimar.Services;

namespace Nikimar.Controllers
{
    [Route("api/movies/{movieId}/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDto>> AddReview(int movieId, [FromBody] ReviewDto reviewDto)
        {
            reviewDto.MovieId = movieId; 
            var createdReview = await _reviewService.AddReviewAsync(reviewDto);
            return CreatedAtAction("AddReview", new { movieId = movieId, id = createdReview.Id }, createdReview);
        }
    }

}
