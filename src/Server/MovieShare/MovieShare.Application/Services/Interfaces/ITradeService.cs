using MovieShare.Domain.Dtos;

namespace MovieShare.Application.Services.Interfaces
{
    public interface ITradeService
    {
        Task<List<TradeDto>> GetTradesByRequesterIdAsync(int requesterId, int index, int itemsCount);
        Task<List<TradeDto>> GetTradesByReceiverIdAsync(int receiverId, int index, int itemsCount);
        Task<TradeDto> SendTradeRequestAsync(TradeDto tradeDto);
        Task<TradeDto> AcceptTradeRequestAsync(int tradeId, int userId);
        Task DeclineTradeRequestAsync(int tradeId);
    }
}
