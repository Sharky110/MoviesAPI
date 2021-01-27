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
               
        public async Task<Movie> CreateMovieAsync(Movie newMovie)
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

        public async Task<Movie> GetMovieByIdAsync(Guid id)
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
            movieToBeUpdated.Name = movie.Name;
         //   movieToBeUpdated.GenreId = music.GenreId;

            await _unitOfWork.CommitAsync();
        }

        public async Task AddGenreToMovie(string movieName, string genreName)
        {
            var genre = new Genre(genreName);
            
            await _unitOfWork.Genres.AddAsync(genre);
            
            var movie = await _unitOfWork.Movies.GetByNameAsync(movieName);
            movie.Genres.Add(genre);

            await _unitOfWork.CommitAsync();
        }

    }
}
