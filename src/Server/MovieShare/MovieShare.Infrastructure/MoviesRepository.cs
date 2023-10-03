using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Entities;

namespace MovieShare.Infrastructure
{
	public class MoviesRepository : BaseRepository<Movie>
	{
		public MoviesRepository(MovieDbContext context) : base(context)
		{
		}

		public async Task<List<Movie>> GetByPopularity(int page = 0, int itemsCount = 20)
		{
			var movies = await _dbSet
				.OrderByDescending(x => x.Popularity)
				.Skip(page * itemsCount)
				.Take(itemsCount)
				.ToListAsync();

			return movies;
		}

		public async Task<List<Movie>> GetByTopRated(int page = 0, int itemsCount = 20)
		{
			var movies = await _dbSet
				.OrderByDescending(x => x.VoteAverage)
				.Skip(page * itemsCount)
				.Take(itemsCount)
				.ToListAsync();

			return movies;
		}

		public async Task<List<Movie>> GetByRated(int minRated, int maxRated, int page = 0, int itemsCount = 20)
		{
			var movies = await _dbSet
				.Where(x => x.VoteAverage >= minRated && x.VoteAverage <= maxRated)
				.OrderByDescending(x => x.Popularity)
				.Skip(page * itemsCount)
				.Take(itemsCount)
				.ToListAsync();

			return movies;
		}
	}
}

