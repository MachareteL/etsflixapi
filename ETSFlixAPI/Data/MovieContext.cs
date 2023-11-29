using ETSFlixAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ETSFlixAPI.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }
}
