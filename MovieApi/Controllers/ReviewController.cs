using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dto;

namespace MovieApi.Controllers;

[Route("api")]
[ApiController]
public class ReviewController(MovieApiContext context) : ControllerBase
{
    [HttpGet("movies/{id:int}/reviews")]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetMovieReviews(int id)
    {
        
        var movie = await context.Movie
            .Include(m => m.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id);
        
        if (movie == null) return NotFound("Movie not found");

        return movie
            .Reviews
            .Select(r => new ReviewDto(r)).ToList();


    }
    
}