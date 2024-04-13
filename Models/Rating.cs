using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nikimar.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public double Value { get; set; } 
    }
}
