namespace Nikimar.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public string? Content { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
