using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Infrastructure.Repositories
{
	public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
	{
		public PaymentRepository(MovieDbContext context) : base(context)
		{
		}

		public async Task<List<Payment>> GetByUserIdAsync(int userId, int index, int itemCount)
		{
			return await _dbSet.Where(x => x.UserId == userId)
				.Include(x => x.Movie)
				.Skip(index * itemCount)
				.Take(itemCount)
				.ToListAsync();
		}

		public async Task<Payment> GetByUserIdAndMovieId(int userId, int movieId)
		{
			return await _dbSet
				.FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);
		}
	}
}

