using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Services.Interfaces
{
	public interface ITmdbDataService
	{
        Task<List<Genre>> RequestGenresAsync();
        Task<List<MovieResponseDto>> RequestAllPopularMoviesAsync();
        List<MovieGenre> ReturnMoviesGenres(List<MovieResponseDto> movieDtos);
        List<Movie> MapMovieDtosToMovie(List<MovieResponseDto> movieDtos);
        Task<byte[]> GetMovieImage(string imagePath);
    }
}

