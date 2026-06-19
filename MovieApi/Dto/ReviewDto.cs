using System.ComponentModel.DataAnnotations;
using MovieApi.Models;

namespace MovieApi.Dto;

public class ReviewDto
{
    [Required]
    [StringLength(100)]
    public string ReviewerName { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Comment { get; set; }

    [Required]
    public Rating Rating { get; set; }
}