using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShare.Application.Services.Interfaces;

namespace MovieShare.API.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
	[Authorize]
    public class BillingController : BaseController
	{
		private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpPost]
		public async Task<IActionResult> PurchaseMovieAsync(int movieId)
		{
			await _billingService.PurchaseMovieAsync(UserId, movieId);
			return Ok();
		}
	}
}

