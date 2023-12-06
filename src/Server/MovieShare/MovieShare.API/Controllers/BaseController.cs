using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace MovieShare.API.Controllers
{
	[ApiController]
	public class BaseController : ControllerBase
	{
        internal int UserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}

