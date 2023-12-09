using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
    public class TradeToDto : Profile
    {
        public TradeToDto()
        {
            CreateMap<Trade, TradeDto>().ReverseMap();
        }
    }
}
