using AutoMapper;
using MovieShare.API.Requests.Movie;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
    public class UpdateMovieRequestToDto : Profile
    {
        public UpdateMovieRequestToDto()
        {
            CreateMap<UpdateMovieRequest, MovieDto>();
        }
    }
}
