using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Resources;
using Movies.Core.Models;
using Movies.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _musicService;
        private readonly IMapper _mapper;
        public MoviesController(IMovieService musicService, IMapper mapper)
        {
            _mapper = mapper;
            _musicService = musicService;
        }
       
        [HttpGet("api/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            var movies = await _musicService.GetAllWithGenreAsync();
            var movieResources = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieResource>>(movies);

            return Ok(movieResources);
        }
    }
}
