using System;
using MovieShare.Domain.Entities;

namespace MovieShare.Domain.Interfaces
{
	public interface IPurchasedMovieRepository : IBaseRepository<PurchasedMovie>
	{
        Task<List<PurchasedMovie>> GetByUserIdAsync(int userId, int index, int itemCount);

    }
}

