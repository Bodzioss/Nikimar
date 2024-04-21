using Nikimar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MovieListItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int MovieListId { get; set; }
    public int MovieId { get; set; }
    [ForeignKey("MovieListId")] 
    public MovieList MovieList { get; set; }
    [ForeignKey("MovieId")] 
    public Movie Movie { get; set; }
}
