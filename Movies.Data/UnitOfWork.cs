using Movies.Core;
using Movies.Core.Repositories;
using Movies.Data.Repositories;
using System.Threading.Tasks;

namespace Movies.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _context;
        private MovieRepository _movieRepository;
        private GenreRepository _genreRepository;

        public UnitOfWork(MovieDbContext context)
        {
            this._context = context;
        }

        public IMovieRepository Movies => _movieRepository ??= new MovieRepository(_context);

        public IGenreRepository Genres => _genreRepository ??= new GenreRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
