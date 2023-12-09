﻿using MovieShare.Domain.Entities;

namespace MovieShare.Domain.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<Review?> GetByUserIdAndMovieIdAsync(int userId, int movieId);
        Task<bool> IsExistByUserIdAsync(int userId);
        Task<List<Review>> GetMovieReviews(int movieId, int index, int itemsCount);
    }
}