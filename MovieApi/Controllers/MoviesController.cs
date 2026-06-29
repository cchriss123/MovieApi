using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dto;
using MovieApi.Mapper;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController(MovieApiContext context, ILogger<MoviesController> logger) : ControllerBase
{
    // GET: api/Movies
    [HttpGet]
    public async Task<IEnumerable<MovieDto>> GetMovie()
    {
        logger.LogInformation("Fetching all movies.");
        return MovieMapper.MapMovies(await context.Movie.ToListAsync());
    }

    // GET: api/Movies/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieDto>> GetMovie(int id)
    {
        if (logger.IsEnabled(LogLevel.Information)) 
            logger.LogInformation("Fetching movie with id {MovieId}.", id);

        var movie = await context.Movie.FindAsync(id);

        if (movie != null) return new MovieDto(movie);
        logger.LogWarning("Movie with id {MovieId} was not found.", id);
        return NotFound();
    }

    // GET: api/Movies/5/details
    [HttpGet("{id:int}/details")]
    public async Task<ActionResult<MovieDetailDto>> GetMovieDetail(int id)
    {
        if (logger.IsEnabled(LogLevel.Information)) 
            logger.LogInformation("Fetching details for movie with id {MovieId}.", id);

        var movie = await context.Movie
            .Include(m => m.MovieDetails)
            .Include(m => m.Actors)
            .Include(m => m.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie != null) 
            return new MovieDetailDto(movie);
        
        logger.LogWarning("Movie with id {MovieId} was not found.", id);
        return NotFound();
    }

    // POST: api/Movies
    [HttpPost]
    public async Task<ActionResult<MovieDto>> PostMovie(MovieCreateDto createMovieDto)
    {
        var movie = MovieMapper.MapCreate(createMovieDto);
        context.Movie.Add(movie);
        await context.SaveChangesAsync();

        if (logger.IsEnabled(LogLevel.Information)) 
            logger.LogInformation("Movie with id {MovieId} was created.", movie.Id);

        return CreatedAtAction("GetMovie", new { id = movie.Id }, new MovieDto(movie));
    }

    // PUT: api/Movies/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutMovie(int id, MovieUpdateDto movieUpdateDto)
    {
        if (logger.IsEnabled(LogLevel.Information)) 
            logger.LogInformation("Updating movie with id {MovieId}.", id);

        var movie = await context.Movie.FindAsync(id);

        if (movie == null)
        {
            logger.LogWarning("Movie with id {MovieId} was not found.", id);
            return NotFound();
        }

        MovieMapper.MapUpdate(movie, movieUpdateDto);

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            logger.LogWarning(ex, "Concurrency error while updating movie with id {MovieId}.", id);

            if (!MovieExists(id))
                return NotFound();

            throw;
        }

        return Ok(new MovieDto(movie));
    }

    // DELETE: api/Movies/5
    public async Task<IActionResult> DeleteMovie(int id)
    {
        if (logger.IsEnabled(LogLevel.Information)) logger.LogInformation("Deleting movie with id {MovieId}.", id);

        var movie = await context.Movie.FindAsync(id);

        if (movie == null)
        {
            logger.LogWarning("Cannot delete movie with id {MovieId} because it was not found.", id);
            return NotFound();
        }

        context.Movie.Remove(movie);
        await context.SaveChangesAsync();

        if (logger.IsEnabled(LogLevel.Information)) 
            logger.LogInformation("Movie with id {MovieId} was deleted.", id);

        return NoContent();
    }

    private bool MovieExists(int id)
    {
        return context.Movie.Any(e => e.Id == id);
    }
}