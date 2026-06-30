#pragma warning disable CS1591
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dto;
namespace MovieApi.Controllers;

[Route("api")]
[ApiController]
public class ReviewController(MovieApiContext context, ILogger<ReviewController> logger) : ControllerBase
{
    // GET: api/movies/{id}/reviews
    [HttpGet("movies/{id:int}/reviews")]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetMovieReviews(int id)
    {
        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation("Fetching reviews for movie with id {MovieId}.", id);

        var movie = await context.Movie
            .Include(m => m.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
        {
            logger.LogWarning("Movie with id {MovieId} was not found.", id);
            return NotFound("Movie not found");
        }

        return movie.Reviews
            .Select(r => new ReviewDto(r))
            .ToList();
    }
    
}