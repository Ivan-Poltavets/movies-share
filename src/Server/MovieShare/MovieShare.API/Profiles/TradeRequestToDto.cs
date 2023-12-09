﻿using AutoMapper;
using MovieShare.API.Requests;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
    public class TradeRequestToDto : Profile
    {
        public TradeRequestToDto()
        {
            CreateMap<TradeRequest, TradeDto>();
        }
    }
}
