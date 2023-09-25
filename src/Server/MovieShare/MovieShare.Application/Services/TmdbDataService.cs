using AutoMapper;
using Microsoft.Extensions.Configuration;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;
using Newtonsoft.Json;

namespace MovieShare.Application.Services
{
	public class TmdbDataService : ITmdbDataService
	{
		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;

		public TmdbDataService(IConfiguration configuration, IMapper mapper)
		{
			_configuration = configuration;
			_mapper = mapper;
		}

		private async Task<List<MovieResponseDto>> RequestPopularMoviesAsync(int pageNumber)
		{
			var requestUrl = $"{_configuration["TmdbApi:PopularMovies"]}?api_key={_configuration["TmdbApi:ApiKey"]}&page={pageNumber}";
			var result = new MoviesPopularResponseDto();

			using(var httpClient = new HttpClient())
			{
				var response = await httpClient.GetAsync(requestUrl);
				if (response.IsSuccessStatusCode)
				{
					var serializedResults = await response.Content.ReadAsStringAsync();
					result = JsonConvert.DeserializeObject<MoviesPopularResponseDto>(serializedResults);
                    return result.results;
                }
			}

			return null;
		}

		public async Task<List<Genre>> RequestGenresAsync()
		{
			using(var httpClient = new HttpClient())
			{
				var response = await httpClient.GetAsync($"{_configuration["TmdbApi:GenreMovieList"]}?api_key={_configuration["TmdbApi:ApiKey"]}");
				if (response.IsSuccessStatusCode)
				{
					var result = JsonConvert.DeserializeObject<GenresResponseDto>(await response.Content.ReadAsStringAsync());
					return _mapper.Map<List<Genre>>(result.genres);
				}
			}

			return new List<Genre>();
		}

		public async Task<List<MovieResponseDto>> RequestAllPopularMoviesAsync()
		{
			var results = new List<MovieResponseDto>();
			for(int i = 1; i <= 500; i++)
			{
				var result = await RequestPopularMoviesAsync(i);
				if(result != null)
				{
                    results.AddRange(result);
                }
			}
			return results;
		}

		public List<MovieGenre> ReturnMoviesGenres(List<MovieResponseDto> movieDtos)
		{
			var moviesGenres = new List<MovieGenre>();
			foreach(var movie in movieDtos)
			{
                foreach (var genreId in movie.genre_ids)
                {
                    moviesGenres.Add(new MovieGenre
                    {
                        GenreId = genreId,
                        MovieId = movie.id
                    });
                }
            }
			return moviesGenres;
		}

		public List<Movie> MapMovieDtosToMovie(List<MovieResponseDto> movieDtos)
		{
			return _mapper.Map<List<Movie>>(movieDtos);
		}
	}
}

