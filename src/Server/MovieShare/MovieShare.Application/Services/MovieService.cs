using AutoMapper;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Application.Services
{
	public class MovieService : IMovieService
	{
		private readonly IMovieRepository _moviesRepository;
		private readonly IMapper _mapper;

		public MovieService(
			IMovieRepository moviesRepository,
			IMapper mapper)
		{
			_moviesRepository = moviesRepository;
			_mapper = mapper;
		}

		public async Task<List<MovieDto>> GetMoviesByGenresAsync(List<GenreDto> genreDtos, int page, int itemsCount)
		{
			var genres = _mapper.Map<List<Genre>>(genreDtos);
			var movies = await _moviesRepository.GetByGenresAsync(genres, page, itemsCount);
			return _mapper.Map<List<MovieDto>>(movies);
		}

		public async Task<List<MovieDto>> GetMoviesByPopularityAsync(int page, int itemsCount)
		{
			var movies = await _moviesRepository.GetByPopularityAsync(page, itemsCount);
			return _mapper.Map<List<MovieDto>>(movies);
		}

		public async Task<List<MovieDto>> GetMoviesByRatedAsync(RatedDto ratedDto, int page, int itemsCount)
		{
			var movies = await _moviesRepository.GetByRatedAsync(ratedDto.MinRated, ratedDto.MaxRated, page, itemsCount);
			return _mapper.Map<List<MovieDto>>(movies);
		}

		public async Task<List<MovieDto>> GetMoviesByTopRatedAsync(int page, int itemsCount)
		{
			var movies = await _moviesRepository.GetByTopRatedAsync(page, itemsCount);
			return _mapper.Map<List<MovieDto>>(movies);
		}
	}
}

