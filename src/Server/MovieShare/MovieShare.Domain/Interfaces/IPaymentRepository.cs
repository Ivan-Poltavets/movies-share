using MovieShare.Domain.Entities;

namespace MovieShare.Domain.Interfaces
{
	public interface IPaymentRepository : IBaseRepository<Payment>
	{
        Task<List<Payment>> GetByUserIdAsync(int userId, int index, int itemCount);
        Task<Payment> GetByUserIdAndMovieId(int userId, int movieId);
    }
}

