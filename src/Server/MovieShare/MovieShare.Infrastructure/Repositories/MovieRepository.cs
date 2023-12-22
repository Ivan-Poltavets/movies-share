using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Infrastructure.Repositories
{
	public class MovieRepository : BaseRepository<Movie>, IMovieRepository
	{
		public MovieRepository(MovieDbContext context) : base(context)
		{
		}

		public async Task<Movie?> GetMovieById(int id)
		{
			return await _dbSet
				.Include(x => x.MovieGenres)
				.ThenInclude(x => x.Genre)
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Movie>> GetByPopularityAsync(int page, int itemsCount)
		{
			var movies = await _dbSet
				.OrderByDescending(x => x.Popularity)
				.Skip(page * itemsCount)
				.Take(itemsCount)
				.AsNoTracking()
				.ToListAsync();

			return movies;
		}

		public async Task<List<Movie>> GetByTopRatedAsync(int page, int itemsCount)
		{
			var movies = await _dbSet
				.OrderByDescending(x => x.VoteAverage)
				.Skip(page * itemsCount)
				.Take(itemsCount)
				.AsNoTracking()
				.ToListAsync();

			return movies;
		}

		public async Task<List<Movie>> GetByRatedAsync(int minRated, int maxRated, int page, int itemsCount)
		{
			var movies = await _dbSet
				.Where(x => x.VoteAverage >= minRated && x.VoteAverage <= maxRated)
				.OrderByDescending(x => x.Popularity)
				.Skip(page * itemsCount)
				.Take(itemsCount)
				.AsNoTracking()
				.ToListAsync();

			return movies;
		}

		public async Task<List<Movie>> GetByGenresAsync(List<Genre> genres, int page, int itemsCount)
		{
			var moviesGenres = await _context.MoviesGenres
				.Where(x => genres.Contains(
					new Genre
					{
						Id = x.GenreId
					}))
				.Skip(page * itemsCount)
				.Take(itemsCount)
				.AsNoTracking()
				.ToListAsync();

			var movies = await _dbSet
				.Where(x => moviesGenres.Contains(
				new MovieGenre
				{
					MovieId = x.Id
				}))
				.Skip(page * itemsCount)
				.Take(itemsCount)
				.AsNoTracking()
				.ToListAsync();

			return movies;
		}

		public async Task<decimal> GetPriceByMovieIdAsync(int movieId)
		{
			var movie = await _dbSet.FindAsync(movieId);
			if(movie == null)
			{
				throw new Exception("Not found");
			}
			return movie.Price;
		}
	}
}

