using Microsoft.EntityFrameworkCore;
using Movies.Core.Models;
using Movies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Genre>> GetAllWithMoviesAsync()
        {
            return await MovieDbContext.Genres
                .Include(a => a.Movies)
                .ToListAsync();
        }

        public Task<Genre> GetWithMoviesByIdAsync(Guid id)
        {
            return MovieDbContext.Genres
                .Include(a => a.Movies)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private MovieDbContext MovieDbContext
        {
            get { return Context as MovieDbContext; }
        }
    }
}
