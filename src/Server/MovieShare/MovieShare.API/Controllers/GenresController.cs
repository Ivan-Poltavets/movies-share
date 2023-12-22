using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShare.API.Requests.Genre;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Controllers
{
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GenreDto>> GetAsync()
        {
            var genres = await _genreService.GetAsync();
            return Ok(genres);
        }

        [Authorize(Policy = "RequireAdministrator")]
        [HttpPost]
        public async Task<ActionResult<GenreDto>> CreateAsync(CreateGenreRequest createGenreRequest)
        {
            var genreDto = _mapper.Map<GenreDto>(createGenreRequest);
            var createdGenre = await _genreService.CreateAsync(genreDto);
            return StatusCode(201, createdGenre);
        }

        [Authorize(Policy = "RequireAdministrator")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateGenreRequest updateGenreRequest)
        {
            var genreDto = _mapper.Map<GenreDto>(updateGenreRequest);
            await _genreService.UpdateAsync(genreDto);
            return NoContent();
        }

        [Authorize(Policy = "RequireAdministrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreAsync(int id)
        {
            await _genreService.DeleteAsync(id);
            return NoContent();
        }
    }
}

