using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dto;

public class MovieUpdateDto
{
    
    
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Genre { get; set; } = string.Empty;

    [Range(1850, 2200)]
    public int Year { get; set; }

    [Required]
    [StringLength(20)]
    public string Duration { get; set; } = string.Empty;
}