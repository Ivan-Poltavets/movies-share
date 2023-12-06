using System;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Application.Services
{
	public class BillingService : IBillingService
	{
		private readonly IMovieService _movieService;
		private readonly IPurchasedMovieRepository _purchasedMovieRepository;

        public BillingService(IMovieService movieService, IPurchasedMovieRepository purchasedMovieRepository)
        {
            _movieService = movieService;
            _purchasedMovieRepository = purchasedMovieRepository;
        }

        public async Task PurchaseMovieAsync(int userId, int movieId)
		{
			var movie = await _movieService.GetMovieById(movieId);
			var purchasedMovie = new PurchasedMovie
			{
				MovieId = movieId,
				Price = movie.Price,
				UserId = userId,
				DateTime = DateTime.UtcNow
			};

			await _purchasedMovieRepository.CreateAsync(purchasedMovie);
		}
	}
}

