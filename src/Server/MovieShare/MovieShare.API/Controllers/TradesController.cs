using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShare.API.Requests;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : BaseController
    {
        private readonly ITradeService _tradeService;
        private readonly IMapper _mapper;

        public TradesController(ITradeService tradeService, IMapper mapper)
        {
            _tradeService = tradeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TradeDto>> GetCurrentTradeRequests(int index = 0, int itemsCount = 20)
        {
            var trades = await _tradeService.GetTradesByReceiverIdAsync(UserId, index, itemsCount);
            return Ok(trades);
        }

        [HttpGet]
        [Route("sended")]
        public async Task<ActionResult<TradeDto>> GetSendedTradeRequests(int index = 0, int itemsCount = 20)
        {
            var trades = await _tradeService.GetTradesByRequesterIdAsync(UserId, index, itemsCount);
            return Ok(trades);
        }

        [HttpPut]
        public async Task<IActionResult> AcceptTradeRequest(int tradeId)
        {
            await _tradeService.AcceptTradeRequestAsync(tradeId, UserId);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeclineTradeRequest(int tradeId)
        {
            await _tradeService.DeclineTradeRequestAsync(tradeId);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> SendTradeRequest(TradeRequest tradeRequest)
        {
            var tradeDto = _mapper.Map<TradeDto>(tradeRequest);
            tradeDto.RequesterId = UserId;
            var result = await _tradeService.SendTradeRequestAsync(tradeDto);
            return Ok(result);
        }
    }
}
