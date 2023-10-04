using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
	public class GenreToDto : Profile
	{
		public GenreToDto()
		{
			CreateMap<Genre, GenreDto>().ReverseMap();
		}
	}
}

