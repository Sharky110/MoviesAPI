using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllWithGenreAsync();
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<IEnumerable<Movie>> GetMoviesByGenreIdAsync(Guid genreId);
        Task<Movie> CreateMovieAsync(Movie newMovie);
        Task UpdateMovieAsync(Movie movieToBeUpdated, Movie movie);
        Task DeleteMovieAsync(Movie movie);
        Task AddGenreToMovie(string movieName, string genreName);
    }
}
