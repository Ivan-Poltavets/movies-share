using System;
using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Infrastructure.Repositories
{
	public class PurchasedMovieRepository : BaseRepository<PurchasedMovie>, IPurchasedMovieRepository
	{
		public PurchasedMovieRepository(MovieDbContext context) : base(context)
		{
		}

		public async Task<List<PurchasedMovie>> GetByUserIdAsync(int userId, int index, int itemCount)
		{
			return await _dbSet.Where(x => x.UserId == userId)
				.Skip(index * itemCount)
				.Take(itemCount)
				.ToListAsync();
		}
	}
}

