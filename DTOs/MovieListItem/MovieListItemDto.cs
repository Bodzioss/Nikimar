namespace Nikimar.DTOs.MovieListItem
{
    public class MovieListItemDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int MovieListId { get; set; }
        public string? MovieTitle { get; set; }
    }
}
