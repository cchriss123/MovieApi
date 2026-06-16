namespace MovieApi.Models;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public int Year { get; set; }
    public required string Duration { get; set; }
    public MovieDetails? MovieDetails { get; set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Actor> Actors { get; set; } = new List<Actor>();
}