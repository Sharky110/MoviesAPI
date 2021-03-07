using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(Guid id);
        Task<Genre> AddGenre(Genre newGenre);
        Task UpdateGenre(Genre genreToBeUpdated, Genre genre);
        Task DeleteGenre(Genre genre);
    }
}
