namespace MovieApi.Models;

public class MovieDetails
{
    public int Id { get; set; }
    public string? Synopsis { get; set; }
    public required string  Language { get; set; }
    public string? Budget { get; set; }
}