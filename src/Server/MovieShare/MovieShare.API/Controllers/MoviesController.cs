using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShare.API.Requests.Movie;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("popular")]
        public async Task<ActionResult<MovieDto>> GetMoviesByPopularity(int page = 0, int itemsCount = 20)
        {
            var result = await _movieService.GetMoviesByPopularityAsync(page, itemsCount);
            return Ok(result);
        }

        [Route("genres")]
        [HttpGet]
        public async Task<ActionResult<MovieDto>> GetMoviesByGenres(List<GenreDto> genreDtos, int page = 0, int itemsCount = 20)
        {
            var result = await _movieService.GetMoviesByGenresAsync(genreDtos, page, itemsCount);
            return Ok(result);
        }

        [Route("top_rated")]
        [HttpGet]
        public async Task<ActionResult<MovieDto>> GetMoviesByTopRated(int page = 0, int itemsCount = 20)
        {
            var result = await _movieService.GetMoviesByTopRatedAsync(page, itemsCount);
            return Ok(result);
        }

        [Route("rated")]
        [HttpGet]
        public async Task<ActionResult<MovieDto>> GetMoviesByRated(MoviesByRatedRequest request, int page = 0, int itemsCount = 20)
        {
            var rated = _mapper.Map<RatedDto>(request);
            var result = await _movieService.GetMoviesByRatedAsync(rated, page, itemsCount);
            return Ok(result);
        }

        [Authorize(Policy = "RequireAdministrator")]
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequest createMovieRequest)
        {
            var movieDto = _mapper.Map<MovieDto>(createMovieRequest);
            var result = await _movieService.CreateMovieAsync(movieDto);
            return Ok(result);
        }

        [Authorize(Policy = "RequireAdministrator")]
        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieRequest updateMovieRequest)
        {
            var movieDto = _mapper.Map<MovieDto>(updateMovieRequest);
            await _movieService.UpdateMovieAsync(movieDto);
            return NoContent();
        }

        [Authorize(Policy = "RequireAdministrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovieDetailsById(int id)
        {
            var result = await _movieService.GetMovieById(id);
            return Ok(result);
        }
    }
}

