namespace Nikimar.DTOs
{
    public class MovieListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserId { get; set; }
        public List<MovieListItemDto> Items { get; set; } = new List<MovieListItemDto>();
    }
}
