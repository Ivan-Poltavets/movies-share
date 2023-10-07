using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
	public class UserToDto : Profile
	{
		public UserToDto()
		{
			CreateMap<User, UserDto>().ReverseMap();
		}
	}
}

