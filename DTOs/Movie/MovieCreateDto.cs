﻿namespace Nikimar.DTOs.Movie
{
    public class MovieCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ReleaseYear { get; set; }
        public string? Genre { get; set; }
    }
}
