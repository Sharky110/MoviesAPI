using Movies.Core;
using Movies.Core.Models;
using Movies.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovieService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Movie> AddMovieAsync(Movie newMovie)
        {
            await _unitOfWork.Movies.AddAsync(newMovie);
            await _unitOfWork.CommitAsync();
            return newMovie;
        }

        public async Task DeleteMovieAsync(Movie music)
        {
            _unitOfWork.Movies.Remove(music);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllWithGenreAsync()
        {
            return await _unitOfWork.Movies
                .GetAllWithGenreAsync();
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return await _unitOfWork.Movies
                .GetWithGenreByIdAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreIdAsync(Guid genreId)
        {
            return await _unitOfWork.Movies
                .GetAllWithGenreByGenreIdAsync(genreId);
        }

        public async Task UpdateMovieAsync(Movie movieToBeUpdated, Movie movie)
        {
            if (!string.IsNullOrEmpty(movie.Name))
                movieToBeUpdated.Name = movie.Name;
            if (!string.IsNullOrEmpty(movie.Tagline))
                movieToBeUpdated.Tagline = movie.Tagline;
            if (!string.IsNullOrEmpty(movie.Director))
                movieToBeUpdated.Director = movie.Director;
            if (!string.IsNullOrEmpty(movie.Country))
                movieToBeUpdated.Country = movie.Country;
            if (movie.Release != DateTime.MinValue)
                movieToBeUpdated.Release = movie.Release;
            await _unitOfWork.CommitAsync();
        }

        public async Task AddGenreToMovieAsync(Movie movie, Genre genre)
        {
            movie.Genres.Add(genre);
            await _unitOfWork.CommitAsync();
        }
        
        public async Task RemoveGenreToMovieAsync(Movie movie, Genre genre)
        {
            movie.Genres.Remove(genre);
            await _unitOfWork.CommitAsync();
        }

    }
}
