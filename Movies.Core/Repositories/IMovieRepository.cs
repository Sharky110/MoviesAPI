using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IAsyncEnumerable<Movie>> GetAllWithGenreAsync();
        Task<Movie> GetWithGenreByIdAsync(int id);
        Task<IAsyncEnumerable<Movie>> GetAllWithGenreByGenreIdAsync(int genreId);
    }
}
