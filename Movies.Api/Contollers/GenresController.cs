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
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _mapper = mapper;
            _genreService = genreService;
        }

        [HttpGet("{genreId}")]
        public async Task<ActionResult<GenreResource>> GetGenreById(Guid genreId)
        {
            var genre = await _genreService.GetGenreById(genreId);
            var genreResource = _mapper.Map<Genre, GenreResource>(genre);
            return Ok(genreResource);
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<GenreResource>>> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenres();
            var genreResources = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreResource>>(genres);
            return Ok(genreResources);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddGenre([FromBody] GenreResource genreResource)
        {
            var genreToAdd = _mapper.Map<Genre>(genreResource);
            await _genreService.AddGenre(genreToAdd);
            return Ok("Genre added.");
        }

        [HttpPut("Update/{genreId}")]
        public async Task<IActionResult> UpdateGenre(Guid genreId, [FromBody] GenreResource genreResource)
        {
            var genreToBeUpdated = await _genreService.GetGenreById(genreId);
            if (genreToBeUpdated == null)
                return NotFound("Error. Genre not found.");

            var genre = _mapper.Map<Genre>(genreResource);
            await _genreService.UpdateGenre(genreToBeUpdated, genre);
            return Ok("Movie updated.");
        }

        [HttpDelete("Delete/{genreId}")]
        public async Task<IActionResult> DeleteGenre(Guid genreId)
        {
            var genre = await _genreService.GetGenreById(genreId);
            if (genre == null)
                return NotFound("Error. Movie not found.");

            await _genreService.DeleteGenre(genre);
            return Ok("Genre deleted.");
        }
    }
}
