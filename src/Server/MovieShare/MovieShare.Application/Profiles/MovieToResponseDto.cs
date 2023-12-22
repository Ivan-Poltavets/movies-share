using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
	public class MovieToResponseDto : Profile
	{
		public MovieToResponseDto()
		{
            CreateMap<MovieResponseDto, Movie>()
                .ForMember(x => x.Adult, opt => opt.MapFrom(dto => dto.adult))
                .ForMember(x => x.BackdropPath, opt => opt.MapFrom(dto => dto.backdrop_path))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.TmdbId, opt => opt.MapFrom(dto => dto.id))
                .ForMember(x => x.OriginalLanguage, opt => opt.MapFrom(dto => dto.original_language))
                .ForMember(x => x.OriginalTitle, opt => opt.MapFrom(dto => dto.original_title))
                .ForMember(x => x.Overview, opt => opt.MapFrom(dto => dto.overview))
                .ForMember(x => x.Popularity, opt => opt.MapFrom(dto => dto.popularity))
                .ForMember(x => x.PosterPath, opt => opt.MapFrom(dto => dto.poster_path))
                .ForMember(x => x.ReleaseDate, opt => opt.MapFrom(dto => dto.release_date))
                .ForMember(x => x.Title, opt => opt.MapFrom(dto => dto.title))
                .ForMember(x => x.VoteAverage, opt => opt.MapFrom(dto => dto.vote_average))
                .ForMember(x => x.VoteCount, opt => opt.MapFrom(dto => dto.vote_count));
        }
	}
}

