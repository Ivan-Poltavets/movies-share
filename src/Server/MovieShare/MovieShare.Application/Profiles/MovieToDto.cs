using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
	public class MovieToDto : Profile
	{
		public MovieToDto()
		{
			CreateMap<Movie, MovieDto>().ReverseMap();
		}
	}
}

