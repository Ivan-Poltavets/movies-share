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

		public async Task<Movie> GetMovieById(int movieId)
		{
            var movie = await _moviesRepository.GetByIdAsync(movieId);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            return movie;
		}

		public async Task<MovieDto> CreateMovieAsync(MovieDto movieDto)
		{
			var movie = _mapper.Map<Movie>(movieDto);
			await _moviesRepository.CreateAsync(movie);
			return _mapper.Map<MovieDto>(movie);
		}

		public async Task UpdateMovieAsync(MovieDto movieDto)
		{
			var movie = _mapper.Map<Movie>(movieDto);
			await _moviesRepository.UpdateAsync(movie);
		}

		public async Task UpdateByAddingReviewAsync(ReviewDto reviewDto)
		{
			var movie = await GetMovieById(reviewDto.MovieId);
			var summary = movie.VoteAverage * movie.VoteCount + reviewDto.Rating;
			movie.VoteCount += 1;
			movie.VoteAverage = summary / movie.VoteCount;
            await _moviesRepository.UpdateAsync(movie);
        }

		public async Task UpdateByUpdatingReviewAsync(ReviewDto newReview, ReviewDto prevReview)
		{
            var movie = await GetMovieById(newReview.MovieId);
            var summary = movie.VoteCount * movie.VoteAverage - prevReview.Rating + newReview.Rating;
            movie.VoteAverage = summary / movie.VoteCount;
            await _moviesRepository.UpdateAsync(movie);
        }

		public async Task UpdateByDeletingReviewAsync(ReviewDto reviewDto)
		{
            var movie = await GetMovieById(reviewDto.MovieId);
			var summary = movie.VoteCount * movie.VoteAverage - reviewDto.Rating;
			movie.VoteCount -= 1;
			movie.VoteAverage = summary / movie.VoteCount;
			await _moviesRepository.UpdateAsync(movie);
        }

		public async Task DeleteMovieAsync(int id)
		{
			await _moviesRepository.DeleteAsync(id);
		}
	}
}

