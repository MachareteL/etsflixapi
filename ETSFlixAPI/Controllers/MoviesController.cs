using ETSFlixAPI.Data;
using ETSFlixAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ETSFlixAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private MovieContext context;
    public MoviesController(MovieContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        context.Movies.Add(movie);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public List<Movie> GetMovies()
    {
        return context.Movies.ToList();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Console.WriteLine("\n\nBYID!!\n\n");
        var movie = context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);

    }

    [HttpGet("/page")]
    public List<Movie> GetPages([FromQuery] int skip, [FromQuery] int take)
    {
        return context.Movies.Skip(skip).Take(take).ToList();
    }
}
