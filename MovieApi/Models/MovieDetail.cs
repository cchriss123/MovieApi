using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class MovieDetail
{
    public int Id { get; set; }

    [StringLength(2000)]
    public string? Synopsis { get; set; }

    [StringLength(50)]
    public required string Language { get; set; }

    [StringLength(50)]
    public string? Budget { get; set; }
}