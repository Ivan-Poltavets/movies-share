using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using MovieShare.API;
using MovieShare.Infrastructure;
using MovieShare.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var appContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
    var databaseExists = appContext.Database.GetService<IRelationalDatabaseCreator>().Exists();

    if (!databaseExists)
    {
        try
        {
            appContext.Database.EnsureCreated();
            appContext.Database.Migrate();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Migration was failed: {ex.Message}");
        }

        var tmdbDataService = scope.ServiceProvider.GetRequiredService<TmdbDataService>();

        var genres = await tmdbDataService.RequestGenresAsync();
        appContext.Genres.AddRange(genres);

        var movieDtos = await tmdbDataService.RequestAllPopularMoviesAsync();
        var movies = tmdbDataService.MapMovieDtosToMovie(movieDtos);
        appContext.Movies.AddRange(movies);

        var moviesGenres = tmdbDataService.ReturnMoviesGenres(movieDtos);
        appContext.MoviesGenres.AddRange(moviesGenres);
        appContext.SaveChanges();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
