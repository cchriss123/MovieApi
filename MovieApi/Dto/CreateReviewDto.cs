using MovieApi.Models;

public class ReviewCreateDto
{
    public required string ReviewerName { get; set; }
    public string? Comment { get; set; }
    public Rating Rating { get; set; }
}