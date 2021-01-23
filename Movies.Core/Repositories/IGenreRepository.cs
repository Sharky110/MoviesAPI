using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IAsyncEnumerable<Genre>> GetAllWithMoviesAsync();
        Task<Genre> GetWithMoviesByIdAsync(int id);
    }
}
