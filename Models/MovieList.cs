﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nikimar.Models
{
    public class MovieList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public IdentityUser? User { get; set; } 
        public string? UserId { get; set; } 

    public List<MovieListItem> Items { get; set; } = new List<MovieListItem>();
    }

}
