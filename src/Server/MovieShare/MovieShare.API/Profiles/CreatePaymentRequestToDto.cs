using AutoMapper;
using MovieShare.API.Requests;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Profiles
{
    public class CreatePaymentRequestToDto : Profile
    {
        public CreatePaymentRequestToDto()
        {
            CreateMap<CreatePaymentRequest, PaymentDto>();
        }
    }
}
