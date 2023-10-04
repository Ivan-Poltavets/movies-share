using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
	public class MovieToResponseDto : Profile
	{
		public MovieToResponseDto()
		{
            CreateMap<Movie, MovieResponseDto>()
                .ForMember(x => x.adult, opt => opt.MapFrom(dto => dto.Adult))
                .ForMember(x => x.backdrop_path, opt => opt.MapFrom(dto => dto.BackdropPath))
                .ForMember(x => x.id, opt => opt.MapFrom(e => e.Id))
                .ForMember(x => x.original_language, opt => opt.MapFrom(dto => dto.OriginalLanguage))
                .ForMember(x => x.original_title, opt => opt.MapFrom(dto => dto.OriginalTitle))
                .ForMember(x => x.overview, opt => opt.MapFrom(dto => dto.Overview))
                .ForMember(x => x.popularity, opt => opt.MapFrom(dto => dto.Popularity))
                .ForMember(x => x.poster_path, opt => opt.MapFrom(dto => dto.PosterPath))
                .ForMember(x => x.release_date, opt => opt.MapFrom(dto => dto.ReleaseDate))
                .ForMember(x => x.title, opt => opt.MapFrom(dto => dto.Title))
                .ForMember(x => x.video, opt => opt.MapFrom(dto => dto.Video))
                .ForMember(x => x.vote_average, opt => opt.MapFrom(dto => dto.VoteAverage))
                .ForMember(x => x.vote_count, opt => opt.MapFrom(dto => dto.VoteCount))
                .ReverseMap();
        }
	}
}

