using AutoMapper;
using MovieShare.API.Responses;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
    public class UserDtoToResponse : Profile
    {
        public UserDtoToResponse()
        {
            CreateMap<UserDto, UserInfoReponse>();
        }
    }
}
