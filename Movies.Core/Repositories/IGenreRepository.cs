using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAllWithMoviesAsync();
        Task<Genre> GetWithMoviesByIdAsync(Guid id);
    }
}
