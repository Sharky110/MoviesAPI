using Microsoft.EntityFrameworkCore;
using Movies.Core.Models;
using Movies.Data.Configurations;

namespace Movies.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new MovieConfiguration());

            builder
                .ApplyConfiguration(new GenreConfiguration());
        }
    }
}
