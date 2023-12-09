using MovieShare.Domain.Dtos;

namespace MovieShare.Application.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetPaymentsByUserIdAsync(int userId, int index, int itemCount);
        Task<PaymentDto> CreatePaymentAsync(PaymentDto paymentDto);
        Task UpdatePaymentsFromTradeAsync(TradeDto tradeDto);
    }
}
