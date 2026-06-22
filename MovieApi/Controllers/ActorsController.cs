using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorsController(MovieApiContext context) : ControllerBase
{
    // POST /api/movies/{movieId}/actors/{actorId}
    [HttpPost("{movieId:int}/actors/{actorId:int}")]
    public async Task<IActionResult> PostActorToMovie(int movieId, int actorId)
    {
        var movie = await context.Movie
            .Include(m => m.Actors )
            .FirstOrDefaultAsync(m => m.Id == movieId);
            
        var actor = await context.Actor.FindAsync(actorId);

        if (movie == null || actor == null) return NotFound();
            
        if (movie.Actors.Any(a => a.Id == actorId)) return BadRequest("Actor already assigned to movie.");
            
        movie.Actors.Add(actor);
        await context.SaveChangesAsync();
        return Ok("Actor added to movie.");
    }
          
    // Scaffolded code under....

    // GET: api/Actors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Actor>>> GetActor()
    {
        return await context.Actor.ToListAsync();
    }

    // GET: api/Actors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Actor>> GetActor(int id)
    {
        var actor = await context.Actor.FindAsync(id);

        if (actor == null)
        {
            return NotFound();
        }

        return actor;
    }

    // PUT: api/Actors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutActor(int id, Actor actor)
    {
        if (id != actor.Id)
        {
            return BadRequest();
        }

        context.Entry(actor).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ActorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Actors
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Actor>> PostActor(Actor actor)
    {
        context.Actor.Add(actor);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
    }

    // DELETE: api/Actors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActor(int id)
    {
        var actor = await context.Actor.FindAsync(id);
        if (actor == null)
        {
            return NotFound();
        }

        context.Actor.Remove(actor);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool ActorExists(int id)
    {
        return context.Actor.Any(e => e.Id == id);
    }
}