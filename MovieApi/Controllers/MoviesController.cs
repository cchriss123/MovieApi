using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dto;
using MovieApi.Mapper;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(MovieApiContext context) : ControllerBase
    {
        // GET: api/Movies
        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetMovie()
        {
            return MovieMapper.MapMovies(await context.Movie.ToListAsync());
        }

        // GET: api/Movies/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            
            var movie = await context.Movie.FindAsync(id);
            if (movie == null) return NotFound();
            
            return new MovieDto(movie);
        }
        
        // GET: api/Movies/5
        [HttpGet("{id:int}/details")]
        public async Task<ActionResult<MovieDetailDto>> GetMovieDetail(int id)
        {
            
            var movie = await context.Movie
                .Include(m => m.MovieDetails)
                .Include(m => m.Actors)
                .Include(m => m.Reviews)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (movie == null) return NotFound();
            
            return new MovieDetailDto(movie);
        }
        
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieDto>> PostMovie(MovieCreateDto createMovieDto)
        {
            var movie = MovieMapper.MapCreate(createMovieDto);
            context.Movie.Add(movie);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetMovie", new { id = movie.Id }, new MovieDto(movie));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutMovie(int id, MovieUpdateDto movieUpdateDto)
        {

            
            var movie = await context.Movie.FindAsync(id);
            if (movie == null) return NotFound();
            
            MovieMapper.MapUpdate(movie, movieUpdateDto);
            
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                    return NotFound();
                throw;
            }

            return Ok(new MovieDto(movie));
        }

        private bool MovieExists(int id)
        {
            return context.Movie.Any(e => e.Id == id);
        }
    }
}
