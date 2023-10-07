using System;
using AutoMapper;
using MovieShare.API.Requests;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
	public class RegisterRequestToUserDto : Profile
	{
		public RegisterRequestToUserDto()
		{
			CreateMap<RegisterRequest, UserDto>();
		}
	}
}

