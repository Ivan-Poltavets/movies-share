using AutoMapper;
using MovieShare.API.Responses;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
    public class ReviewDtoToResponse : Profile
    {
        public ReviewDtoToResponse()
        {
            CreateMap<ReviewDto, ReviewResponse>();
        }
    }
}
