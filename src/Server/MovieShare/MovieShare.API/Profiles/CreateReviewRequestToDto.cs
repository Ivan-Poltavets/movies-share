using AutoMapper;
using MovieShare.API.Requests.Review;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
    public class CreateReviewRequestToDto : Profile
    {
        public CreateReviewRequestToDto()
        {
            CreateMap<CreateReviewRequest, ReviewDto>();
        }
    }
}
