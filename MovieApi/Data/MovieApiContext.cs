using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Data;

public class MovieApiContext(DbContextOptions<MovieApiContext> options) : DbContext(options)
{
    public DbSet<Movie> Movie { get; set; } = null!;
    public DbSet<Actor> Actor { get; set; } = null!;

    public DbSet<Review> Review { get; set; } = null!;
    public DbSet<MovieDetail> MovieDetails { get; set; } = null!;
}