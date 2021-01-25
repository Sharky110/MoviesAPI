using Movies.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Services
{
    interface IMovieService
    {
        Task<IAsyncEnumerable<Movie>> GetAllWithGenreAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<IAsyncEnumerable<Movie>> GetMoviesByGenreIdAsync(int genreId);
        Task<Movie> CreateMovieAsync(Movie newMovie);
        Task UpdateMovieAsync(Movie movieToBeUpdated, Movie movie);
        Task DeleteMovieAsync(Movie movie);
    }
}
