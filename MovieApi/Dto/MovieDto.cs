using MovieApi.Models;

namespace MovieApi.Dto;

public class MovieDto(Movie movie)
{
    public int Id { get; set; } = movie.Id;
    public string Title { get; set; } = movie.Title;
    public string Genre { get; set; } = movie.Genre;
    public int Year { get; set; } = movie.Year;
    public string Duration { get; set; } = movie.Duration;
}
    
    
    
