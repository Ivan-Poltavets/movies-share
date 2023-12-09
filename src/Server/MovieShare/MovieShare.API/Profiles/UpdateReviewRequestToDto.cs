using AutoMapper;
using MovieShare.API.Requests.Review;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
    public class UpdateReviewRequestToDto : Profile
    {
        public UpdateReviewRequestToDto()
        {
            CreateMap<UpdateReviewRequest, ReviewDto>();
        }
    }
}
