using MovieShare.Domain.Dtos;

namespace MovieShare.Application.Services.Interfaces
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetMovieReviewsAsync(int movieId, int index, int itemsCount);
        Task<ReviewDto> GetUserReviewAsync(int movieId, int userId);
        Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto);
        Task UpdateReviewAsync(ReviewDto reviewDto);
        Task DeleteReviewAsync(int id);
    }
}
