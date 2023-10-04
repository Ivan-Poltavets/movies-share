using Microsoft.EntityFrameworkCore;
using MovieShare.Application.Profiles;
using MovieShare.Application.Services;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Interfaces;
using MovieShare.Infrastructure;

namespace MovieShare.API
{
	public static class ServicesConfiguration
	{
		public static void AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<MovieDbContext>(options =>
			{
				options.UseSqlite(configuration.GetConnectionString("MovieDbContext"));
			});
			services.AddAutoMapper(typeof(MovieToDto));

			services.AddScoped<IMoviesRepository, MoviesRepository>();

			services.AddScoped<ITmdbDataService, TmdbDataService>();
			services.AddScoped<IMoviesService, MoviesService>();
		}
	}
}

