using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Services.Interfaces
{
	public interface IMovieService
	{
        Task<List<MovieDto>> GetMoviesByGenresAsync(List<GenreDto> genreDtos, int page, int itemsCount);
        Task<List<MovieDto>> GetMoviesByPopularityAsync(int page, int itemsCount);
        Task<List<MovieDto>> GetMoviesByRatedAsync(RatedDto ratedDto, int page, int itemsCount);
        Task<List<MovieDto>> GetMoviesByTopRatedAsync(int page, int itemsCount);
        Task<Movie> GetMovieById(int movieId);
    }
}

