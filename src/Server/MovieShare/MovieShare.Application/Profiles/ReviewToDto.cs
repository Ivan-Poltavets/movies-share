using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
    public class ReviewToDto : Profile
    {
        public ReviewToDto()
        {
            CreateMap<Review, ReviewDto>().ReverseMap();
        }
    }
}
