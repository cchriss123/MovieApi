#pragma warning disable CS1591

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dto;
using MovieApi.Models;

namespace MovieApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/movies")]
[ApiVersion("1.0")]
public class ReviewController(
    MovieApiContext context,
    ILogger<ReviewController> logger
) : ControllerBase
{
    [HttpGet("{id:int}/reviews")]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetMovieReviews(int id)
    {
        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation(
                "Fetching reviews for movie with id {MovieId}.",
                id
            );

        var movie = await context.Movie
            .Include(m => m.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
        {
            logger.LogWarning(
                "Movie with id {MovieId} was not found.",
                id
            );

            return NotFound("Movie not found");
        }

        return movie.Reviews
            .Select(review => new ReviewDto(review))
            .ToList();
    }

    [HttpPost("{id:int}/reviews")]
    public async Task<ActionResult<ReviewDto>> PostMovieReview(
        int id,
        ReviewCreateDto input
    )
    {
        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation(
                "Adding review to movie with id {MovieId}.",
                id
            );

        var movie = await context.Movie
            .Include(m => m.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
        {
            logger.LogWarning(
                "Movie with id {MovieId} was not found.",
                id
            );

            return NotFound("Movie not found");
        }

        var review = new Review
        {
            ReviewerName = input.ReviewerName,
            Comment = input.Comment,
            Rating = input.Rating
        };

        movie.Reviews.Add(review);
        await context.SaveChangesAsync();

        return Ok(new ReviewDto(review));
    }
}