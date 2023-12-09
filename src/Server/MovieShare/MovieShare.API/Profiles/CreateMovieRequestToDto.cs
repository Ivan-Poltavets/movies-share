using AutoMapper;
using MovieShare.API.Requests.Movie;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
    public class CreateMovieRequestToDto : Profile
    {
        public CreateMovieRequestToDto()
        {
            CreateMap<CreateMovieRequest, MovieDto>();
        }
    }
}
