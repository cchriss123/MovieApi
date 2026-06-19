using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dto;

public class MovieDetailDto
{
    [StringLength(1000)]
    public string? Synopsis { get; set; }

    [Required]
    [StringLength(50)]
    public string Language { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Budget { get; set; }
}