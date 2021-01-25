using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(int id);
        Task<Genre> CreateGenre(Genre newGenre);
        Task UpdateGenre(Genre genreToBeUpdated, Genre genre);
        Task DeleteGenre(Genre genre);
    }
}
