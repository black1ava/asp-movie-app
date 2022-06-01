using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Data {
  public class MovieAppDbContext : DbContext {
    public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options) {

    }
    public DbSet<Movie> Movies { get; set; }
  }
}