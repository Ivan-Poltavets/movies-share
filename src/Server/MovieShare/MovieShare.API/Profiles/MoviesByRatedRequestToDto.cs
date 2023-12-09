using AutoMapper;
using MovieShare.API.Requests.Movie;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
    public class MoviesByRatedRequestToDto : Profile
	{
		public MoviesByRatedRequestToDto()
		{
			CreateMap<MoviesByRatedRequest, RatedDto>();
		}
	}
}

