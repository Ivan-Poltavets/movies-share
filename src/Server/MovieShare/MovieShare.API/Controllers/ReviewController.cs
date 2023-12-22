using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShare.API.Requests.Review;
using MovieShare.API.Responses;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ReviewController : BaseController
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("movies/{movieId}/reviews")]
        public async Task<ActionResult<ReviewResponse>> GetMovieReviews(int movieId, int index = 0, int itemsCount = 20)
        {
            var reviews = await _reviewService.GetMovieReviewsAsync(movieId, index, itemsCount);
            return Ok(_mapper.Map<List<ReviewResponse>>(reviews));
        }

        [Authorize]
        [HttpGet]
        [Route("movies/{movieId}/reviews/{UserId}")]
        public async Task<ActionResult<ReviewDto>> GetUserReviewOfMovie(int movieId)
        {
            var review = await _reviewService.GetUserReviewAsync(movieId, UserId);
            return Ok(review);
        }

        [Authorize]
        [HttpPost]
        [Route("reviews")]
        public async Task<ActionResult<ReviewResponse>> CreateReviewAsync(CreateReviewRequest createReviewRequest)
        {
            var reviewDto = _mapper.Map<ReviewDto>(createReviewRequest);
            reviewDto.UserId = UserId;
            var result = await _reviewService.CreateReviewAsync(reviewDto);
            return Ok(_mapper.Map<ReviewResponse>(result));
        }

        [Authorize]
        [HttpPut]
        [Route("reviews")]
        public async Task<IActionResult> UpdateReviewAsync(UpdateReviewRequest updateReviewRequest)
        {
            var reviewDto = _mapper.Map<ReviewDto>(updateReviewRequest);
            reviewDto.UserId = UserId;
            await _reviewService.UpdateReviewAsync(reviewDto);
            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        [Route("reviews")]
        public async Task<IActionResult> DeleteReviewAsync(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
