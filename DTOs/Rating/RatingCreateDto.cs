namespace Nikimar.DTOs.Rating
{
    public class RatingCreateDto
    {
        public int MovieId { get; set; }
        public string? UserId { get; set; }
        public double Value { get; set; }
    }
}
