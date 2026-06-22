using MovieApi.Models;

namespace MovieApi.Dto;

public class ReviewDto(Review review)
{
    public int Id { get; set; } = review.Id;
    public string ReviewerName { get; set; } = review.ReviewerName;
    public string? Comment { get; set; } = review.Comment;
    public Rating Rating { get; set; } = review.Rating;
}