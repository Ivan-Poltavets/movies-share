using AutoMapper;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Profiles
{
    public class DtoToPayment : Profile
    {
        public DtoToPayment()
        {
            CreateMap<PaymentDto, Payment>().ReverseMap();
        }
    }
}
