using Microsoft.EntityFrameworkCore;
using Movies.Core.Models;
using Movies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Movie>> GetAllWithGenreAsync()
        {
            try
            {
                return await MovieDbContext.Movies
                .Include(m => m.Genres)
                .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<Movie> GetWithGenreByIdAsync(Guid id)
        {
            return await MovieDbContext.Movies
                .Include(m => m.Genres)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAllWithGenreByGenreIdAsync(Guid genreId)
        {
            throw new Exception();
            //return await MovieDbContext.Movies
            //    .Include(m => m.Genres)
            //    .Where(m => m.GenreId == genreId)
            //    .ToListAsync();
        }

        public async Task<Movie> GetByNameAsync(string name)
        {
            return await MovieDbContext.Movies
                .Include(m => m.Genres)
                .Where(_ => _.Name == name)
                .FirstOrDefaultAsync();
        }

        private MovieDbContext MovieDbContext
        {
            get { return Context as MovieDbContext; }
        }
    }
}
