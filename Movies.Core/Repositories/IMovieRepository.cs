﻿using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllWithGenreAsync();
        Task<Movie> GetWithGenreByIdAsync(Guid id);
        Task<IEnumerable<Movie>> GetAllWithGenreByGenreIdAsync(Guid genreId);
        Task<Movie> GetByNameAsync(string name);
    }
}
