using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dto;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController(MovieApiContext context) : ControllerBase
{
    
    // GET /api/movies/{movieId}/reviews
    [HttpGet("{id:int}/reviews")]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetMovieDetails(int id)
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