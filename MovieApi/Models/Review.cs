using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class Review
{
    public int Id { get; set; }

    [StringLength(100)]
    public required string ReviewerName { get; set; }

    [StringLength(1000)]
    public string? Comment { get; set; }

    public Rating Rating { get; set; }
}

public enum Rating
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5
}