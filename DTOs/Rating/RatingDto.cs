namespace Nikimar.DTOs.Rating;
public class RatingDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string? UserId { get; set; }
    public double Value { get; set; }
}
