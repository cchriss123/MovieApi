using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class Movie
{
    public int Id { get; set; }

    [StringLength(100)]
    public required string Title { get; set; }

    [StringLength(50)]
    public required string Genre { get; set; }

    [Range(1850, 2200)]
    public int Year { get; set; }

    [StringLength(20)]
    public required string Duration { get; set; }

    public MovieDetail? MovieDetails { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<Actor> Actors { get; set; } = new List<Actor>();
}