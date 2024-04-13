
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nikimar.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Definicje DbSet dla modeli aplikacji
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<MovieList> MovieLists { get; set; }
    public DbSet<MovieListItem> MovieListItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
