using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Infrastructure.Repositories
{
	public class GenreRepository : BaseRepository<Genre>, IGenreRepository

    {
		public GenreRepository(MovieDbContext context) : base(context)
		{
		}

		public async Task<List<Genre>> GetGenresAsync() =>
			await _dbSet.ToListAsync();
	}
}

