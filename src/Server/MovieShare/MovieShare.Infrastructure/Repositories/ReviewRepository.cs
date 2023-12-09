using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieDbContext context) : base(context)
        {
            
        }

        public async Task<List<Review>> GetMovieReviews(int movieId, int index, int itemsCount)
        {
            return await _dbSet
                .Where(x => x.MovieId == movieId)
                .OrderByDescending(x => x.DateTimeCreated)
                .Skip(index * itemsCount)
                .Take(itemsCount)
                .ToListAsync();
        }

        public async Task<Review?> GetByUserIdAndMovieIdAsync(int userId, int movieId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);
        }

        public async Task<bool> IsExistByUserIdAsync(int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId) != null;
        }
    }
}
