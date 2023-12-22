using AutoMapper;
using MovieShare.Domain.Dtos.Tmdb;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
    public class MovieDetailsResponseToDto : Profile
    {
        public MovieDetailsResponseToDto()
        {
            CreateMap<MovieDetailsResponseDto, Movie>()
                .ForMember(x => x.ImdbId, opt => opt.MapFrom(dto => dto.id))
                .ForMember(x => x.Revenue, opt => opt.MapFrom(dto => dto.revenue))
                .ForMember(x => x.Budget, opt => opt.MapFrom(dto => dto.budget))
                .ForMember(x => x.Runtime, opt => opt.MapFrom(dto => dto.runtime))
                .ForMember(x => x.Tagline, opt => opt.MapFrom(dto => dto.tagline))
                .ForMember(x => x.Homepage, opt => opt.MapFrom(dto => dto.homepage))
                .ForMember(x => x.Adult, opt => opt.Ignore())
                .ForMember(x => x.PosterPath, opt => opt.Ignore())
                .ForMember(x => x.ReleaseDate, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
