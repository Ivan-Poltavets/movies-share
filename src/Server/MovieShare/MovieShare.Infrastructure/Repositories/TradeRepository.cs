using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Infrastructure.Repositories
{
    public class TradeRepository : BaseRepository<Trade>, ITradeRepository
    {
        public TradeRepository(MovieDbContext context) : base(context)
        {
            
        }

        public async Task<List<Trade>> GetByRequesterIdAsync(int requesterId, int index, int itemCount)
        {
            return await _dbSet.Where(x => x.RequesterId == requesterId)
                .Skip(index * itemCount)
                .Take(itemCount)
                .ToListAsync();
        }

        public async Task<List<Trade>> GetByReceiverIdAsync(int receiverId, int index, int itemCount)
        {
            return await _dbSet.Where(x => x.ReceiverId == receiverId)
                .Skip(index * itemCount)
                .Take(itemCount)
                .ToListAsync();
        }
    }
}
