using MovieShare.Domain.Entities;

namespace MovieShare.Domain.Interfaces
{
    public interface ITradeRepository : IBaseRepository<Trade>
    {
        Task<List<Trade>> GetByRequesterIdAsync(int requesterId, int index, int itemCount);
        Task<List<Trade>> GetByReceiverIdAsync(int receiverId, int index, int itemCount);
    }
}
