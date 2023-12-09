using Microsoft.EntityFrameworkCore;
using MovieShare.Application.Profiles;
using MovieShare.Application.Services;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Interfaces;
using MovieShare.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MovieShare.API.Profiles;
using MovieShare.Infrastructure.Repositories;

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
			services.AddAutoMapper(typeof(MovieToDto), typeof(MoviesByRatedRequestToDto));

			services.AddScoped<ITmdbDataService, TmdbDataService>();
			services.AddScoped<IMovieService, MovieService>();
			services.AddScoped<IAuthenticationService, AuthenticationService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IGenreService, GenreService>();
			services.AddScoped<IPaymentService, PaymentService>();
			services.AddScoped<ITradeService, TradeService>();
		}

		public static void AddRepositories(this IServiceCollection services)
		{
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
			services.AddScoped<ITradeRepository, TradeRepository>();
        }

		public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					var encodedSecret = Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]);

					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateAudience = true,
						ValidateIssuer = true,
						ValidateLifetime = true,
						ValidIssuer = configuration["Jwt:Issuer"],
						ValidAudience = configuration["Jwt:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey(encodedSecret)
					};
				});
		}

		public static void AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("V1", new OpenApiInfo
				{
					Version = "V1",
					Title = "MovieShare",
					Description = "MovieShare Web API"
				});

				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Name = "Authorization",
					Description = "Bearer Auth with a JWT",
					Type = SecuritySchemeType.Http
				});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Id = "Bearer",
								Type = ReferenceType.SecurityScheme
							}
						},
						new List<string>()
					}
				});
			});
		}
	}
}

