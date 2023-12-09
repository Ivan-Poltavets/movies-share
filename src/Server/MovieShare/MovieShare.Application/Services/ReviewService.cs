using AutoMapper;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMovieService movieService, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<List<ReviewDto>> GetMovieReviewsAsync(int movieId, int index, int itemsCount)
        {
            var reviews = await _reviewRepository.GetMovieReviews(movieId, index, itemsCount);
            return _mapper.Map<List<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto> GetUserReviewAsync(int movieId, int userId)
        {
            var review = await _reviewRepository.GetByUserIdAndMovieIdAsync(userId, movieId);
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            if(await _reviewRepository.IsExistByUserIdAsync(review.UserId))
            {
                throw new Exception("Review already exist");
            }
            review.DateTimeCreated = DateTime.Now;
            await _reviewRepository.CreateAsync(review);
            await _movieService.UpdateByAddingReviewAsync(reviewDto);

            return _mapper.Map<ReviewDto>(review);
        }

        public async Task UpdateReviewAsync(ReviewDto reviewDto)
        {
            var prevReview = _reviewRepository.GetByIdAsync(reviewDto.Id);
            var prevReviewDto = _mapper.Map<ReviewDto>(prevReview);
            var newReview = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.UpdateAsync(newReview);
            await _movieService.UpdateByUpdatingReviewAsync(reviewDto, prevReviewDto);
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);

            await _movieService.UpdateByDeletingReviewAsync(_mapper.Map<ReviewDto>(review));
            await _reviewRepository.DeleteAsync(id);
        } 
    }
}
