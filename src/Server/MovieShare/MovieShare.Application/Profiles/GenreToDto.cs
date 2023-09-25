using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
	public class GenreToDto : Profile
	{
		public GenreToDto()
		{
			CreateMap<Genre, GenreResponseDto>()
				.ForMember(x => x.id, opt => opt.MapFrom(e => e.Id))
				.ForMember(x => x.name, opt => opt.MapFrom(e => e.Name))
				.ReverseMap();
		}
	}
}

