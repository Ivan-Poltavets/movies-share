using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;
using MovieShare.Domain.Enums;
using MovieShare.Application.Services.Interfaces;

namespace MovieShare.Application.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public TradeService(ITradeRepository tradeRepository, IMapper mapper, IPaymentService paymentService)
        {
            _tradeRepository = tradeRepository;
            _mapper = mapper;
            _paymentService = paymentService;
        }

        public async Task<List<TradeDto>> GetTradesByRequesterIdAsync(int requesterId, int index, int itemsCount)
        {
            var trades = await _tradeRepository.GetByRequesterIdAsync(requesterId, index, itemsCount);
            return _mapper.Map<List<TradeDto>>(trades);
        }

        public async Task<List<TradeDto>> GetTradesByReceiverIdAsync(int receiverId, int index, int itemsCount)
        {
            var trades = await _tradeRepository.GetByReceiverIdAsync(receiverId, index, itemsCount);
            return _mapper.Map<List<TradeDto>>(trades);
        }

        public async Task<TradeDto> SendTradeRequestAsync(TradeDto tradeDto)
        {
            var trade = _mapper.Map<Trade>(tradeDto);
            await _tradeRepository.CreateAsync(trade);
            return _mapper.Map<TradeDto>(trade);
        }

        public async Task<TradeDto> AcceptTradeRequestAsync(int tradeId, int userId)
        {
            var trade = await _tradeRepository.GetByIdAsync(tradeId);
            if(trade == null || trade.ReceiverId != userId)
            {
                throw new Exception("Not found");
            }
            trade.Status = TradeStatus.Accepted;
            await _tradeRepository.UpdateAsync(trade);

            var tradeDto = _mapper.Map<TradeDto>(trade);
            await _paymentService.UpdatePaymentsFromTradeAsync(tradeDto);
            return tradeDto;
        }

        public async Task DeclineTradeRequestAsync(int tradeId)
        {
            var trade = await _tradeRepository.GetByIdAsync(tradeId);
            if(trade == null)
            {
                throw new Exception("Not found");
            }
            trade.Status = TradeStatus.Declined;
            await _tradeRepository.UpdateAsync(trade);
        }
    }
}
