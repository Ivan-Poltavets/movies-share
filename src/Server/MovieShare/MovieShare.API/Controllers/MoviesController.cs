using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieShare.API.Requests;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesService moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("popular")]
        public async Task<ActionResult<MovieDto>> GetMoviesByPopularity(int page = 0, int itemsCount = 20)
        {
            var result = await _moviesService.GetMoviesByPopularityAsync(page, itemsCount);
            return Ok(result);
        }

        [Route("genres")]
        [HttpGet]
        public async Task<ActionResult<MovieDto>> GetGenre(List<GenreDto> genreDtos, int page = 0, int itemsCount = 20)
        {
            var result = await _moviesService.GetMoviesByGenresAsync(genreDtos, page, itemsCount);
            return Ok(result);
        }

        [Route("top_rated")]
        [HttpGet]
        public async Task<ActionResult<MovieDto>> GetMoviesByTopRated(int page = 0, int itemsCount = 20)
        {
            var result = await _moviesService.GetMoviesByTopRatedAsync(page, itemsCount);
            return Ok(result);
        }

        [Route("rated")]
        [HttpGet]
        public async Task<ActionResult<MovieDto>> GetMoviesByRated(MoviesByRatedRequest request, int page = 0, int itemsCount = 20)
        {
            var rated = _mapper.Map<RatedDto>(request);
            var result = await _moviesService.GetMoviesByRatedAsync(rated, page, itemsCount);
            return Ok(result);
        }
    }
}

