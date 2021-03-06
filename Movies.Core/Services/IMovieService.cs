using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllWithGenreAsync();
        Task<Movie> GetMovieById(Guid id);
        Task<IEnumerable<Movie>> GetMoviesByGenreIdAsync(Guid genreId);
        Task<Movie> AddMovieAsync(Movie newMovie);
        Task UpdateMovieAsync(Movie movieToBeUpdated, Movie movie);
        Task DeleteMovieAsync(Movie movie);
        Task AddGenreToMovieAsync(Movie movie, Genre genre);
        Task RemoveGenreToMovieAsync(Movie movie, Genre genre);
    }
}
