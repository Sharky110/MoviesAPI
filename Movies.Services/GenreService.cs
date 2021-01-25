using Movies.Core;
using Movies.Core.Models;
using Movies.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenreService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Genre> CreateGenre(Genre newGenre)
        {
            await _unitOfWork.Genres
                .AddAsync(newGenre);

            return newGenre;
        }

        public async Task DeleteGenre(Genre artist)
        {
            _unitOfWork.Genres.Remove(artist);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _unitOfWork.Genres.GetAllAsync();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _unitOfWork.Genres.GetByIdAsync(id);
        }

        public async Task UpdateGenre(Genre artistToBeUpdated, Genre artist)
        {
            artistToBeUpdated.Name = artist.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
