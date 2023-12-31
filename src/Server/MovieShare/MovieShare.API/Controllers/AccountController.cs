﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieShare.API.Requests;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;

namespace MovieShare.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountController(IAuthenticationService authenticationService, IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var userDto = await _userService.GetByLoginAndPassword(loginRequest.Login, loginRequest.Password);

            if (userDto == null)
                return Unauthorized();

            var expirationPeriod = TimeSpan.FromMinutes(int.Parse(_configuration["Jwt:ExpirationPeriodInMinutes"]));
            var tokenString = _authenticationService.GetTokenString(userDto, expirationPeriod);
            return Ok(tokenString);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var userDto = _mapper.Map<UserDto>(registerRequest);
            userDto = await _userService.CreateAsync(userDto);
            return CreatedAtAction(nameof(Register), userDto);
        }
    }
}

