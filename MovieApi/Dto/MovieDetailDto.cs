using System.ComponentModel.DataAnnotations;
using MovieApi.Models;

namespace MovieApi.Dto;

public class MovieDetailDto(Movie movie)
{
    
    public int Id { get; set; } = movie.Id;
    public string Title { get; set; } = movie.Title;
    public string Genre { get; set; } = movie.Genre;
    public int Year { get; set; } = movie.Year;
    public string Duration { get; set; } = movie.Duration;


    [StringLength(1000)]
    public string? Synopsis { get; set; } = movie.MovieDetails?.Synopsis ?? "";

    [Required]
    [StringLength(50)]
    public string Language { get; set; } = movie.MovieDetails?.Language ?? "";

    [StringLength(50)]
    public string? Budget { get; set; } = movie.MovieDetails?.Budget ?? "";
}