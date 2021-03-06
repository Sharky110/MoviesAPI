using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Resources;
using Movies.Core.Models;
using Movies.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Api.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IGenreService genreService, IMapper mapper)
        {
            _mapper = mapper;
            _movieService = movieService;
            _genreService = genreService;
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<MovieResource>> GetMovieById(Guid movieId)
        {
            var movie = await _movieService.GetMovieById(movieId);
            var movieResource = _mapper.Map<Movie, MovieResource>(movie);
            return Ok(movieResource);
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<MovieResource>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllWithGenreAsync();
            var movieResources = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieResource>>(movies);
            return Ok(movieResources);
        }
        
        [HttpPost("Add")]
        public async Task<IActionResult> AddMovie([FromBody] MovieResource movieResource)
        {
            var movieToAdd = _mapper.Map<Movie>(movieResource);
            await _movieService.AddMovieAsync(movieToAdd);
            return Ok("Movie added.");
        }

        [HttpPut("{movieId}/AddGenre/{genreId}")]
        public async Task<IActionResult> AddGenreToMovie(Guid movieId, Guid genreId)
        {
            var movie = await _movieService.GetMovieById(movieId);
            if (movie == null)
                return NotFound("Error. Movie not found.");

            var genre = await _genreService.GetGenreById(genreId);
            if (genre == null)
                return NotFound("Error. Genre not found.");

            await _movieService.AddGenreToMovieAsync(movie, genre);
            return Ok("Movie updated.");
        }

        [HttpPut("{movieId}/RemoveGenre/{genreId}")]
        public async Task<IActionResult> RemoveGenreFromMovie(Guid movieId, Guid genreId)
        {
            var movie = await _movieService.GetMovieById(movieId);
            if (movie == null)
                return NotFound("Error. Movie not found.");

            var genre = await _genreService.GetGenreById(genreId);
            if (genre == null)
                return NotFound("Error. Genre not found.");

            await _movieService.AddGenreToMovieAsync(movie, genre);
            return Ok("Movie updated.");
        }

        [HttpPut("Update/{movieId}")]
        public async Task<IActionResult> UpdateMovie(Guid movieId, [FromBody] MovieResource movieResource)
        {
            var movieToBeUpdated = await _movieService.GetMovieById(movieId);
            if (movieToBeUpdated == null)
                return NotFound("Error. Movie not found.");

            var movie = _mapper.Map<Movie>(movieResource);
            await _movieService.UpdateMovieAsync(movieToBeUpdated, movie);
            return Ok("Movie updated.");
        }

        [HttpDelete("Delete/{movieId}")]
        public async Task<IActionResult> DeleteMovie(Guid movieId)
        {
            var movie = await _movieService.GetMovieById(movieId);
            if (movie == null)
                return NotFound("Error. Movie not found.");

            await _movieService.DeleteMovieAsync(movie);
            return Ok("Movie deleted.");
        }
    }
}
