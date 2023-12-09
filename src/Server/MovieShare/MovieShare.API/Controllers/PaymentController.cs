using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShare.API.Requests;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PaymentDto>> GetPayments(int index = 0, int itemCount = 20)
        {
            var payments = await _paymentService.GetPaymentsByUserIdAsync(UserId, index, itemCount);
            return Ok(payments);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentRequest createPaymentRequest)
        {
            var paymentDto = _mapper.Map<PaymentDto>(createPaymentRequest);
            paymentDto.UserId = UserId;
            var result = await _paymentService.CreatePaymentAsync(paymentDto);
            return Ok(result);
        }
    }
}
