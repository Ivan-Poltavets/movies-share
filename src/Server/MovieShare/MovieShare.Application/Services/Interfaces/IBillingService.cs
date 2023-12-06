using System;
namespace MovieShare.Application.Services.Interfaces
{
	public interface IBillingService
	{
        Task PurchaseMovieAsync(int userId, int movieId);

    }
}

