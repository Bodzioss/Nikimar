namespace Nikimar.DTOs.Review
{
    public class ReviewCreateDto
    {
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public string? Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
