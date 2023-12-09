using AutoMapper;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper, IMovieRepository movieRepository)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<List<PaymentDto>> GetPaymentsByUserIdAsync(int userId, int index, int itemCount)
        {
            var payments = await _paymentRepository.GetByUserIdAsync(userId, index, itemCount);
            return _mapper.Map<List<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> CreatePaymentAsync(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            payment.DateTime = DateTime.UtcNow;
            payment.Status = Domain.Enums.PaymentStatus.Accepted;
            payment.Price = await _movieRepository.GetPriceByMovieIdAsync(payment.MovieId);
            await _paymentRepository.CreateAsync(payment);
            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task UpdatePaymentsFromTradeAsync(TradeDto tradeDto)
        {
            var requesterPayment = await _paymentRepository.GetByUserIdAndMovieId(tradeDto.RequesterId, tradeDto.RequesterMovieId);
            var receiverPayment = await _paymentRepository.GetByUserIdAndMovieId(tradeDto.ReceiverId, tradeDto.ReceiverMovieId);

            requesterPayment.UserId = tradeDto.ReceiverId;
            receiverPayment.UserId = tradeDto.RequesterId;

            await _paymentRepository.UpdateAsync(requesterPayment);
            await _paymentRepository.UpdateAsync(receiverPayment);
        }
    }
}
