using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using MovieShare.API;
using MovieShare.Infrastructure;
using MovieShare.Application.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServices(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministrator", 
        policy => policy.RequireClaim("Role", "Administrator"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "MovieShare");
    });
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

        var tmdbdataservice = scope.ServiceProvider.GetRequiredService<ITmdbDataService>();

        var genres = await tmdbdataservice.RequestGenresAsync();
        appContext.Genres.AddRange(genres);
        appContext.SaveChanges();

        var moviedtos = await tmdbdataservice.RequestAllPopularMoviesAsync();
        var movies = tmdbdataservice.MapMovieDtosToMovie(moviedtos);
        movies = await tmdbdataservice.GetMoviesDetailsAsync(movies);
        appContext.Movies.AddRange(movies);
        appContext.SaveChanges();

        var moviesgenres = tmdbdataservice.ReturnMoviesGenres(moviedtos, movies);
        appContext.MoviesGenres.AddRange(moviesgenres);
        appContext.SaveChanges();
    }
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
