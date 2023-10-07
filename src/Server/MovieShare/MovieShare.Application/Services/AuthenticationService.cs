using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;

namespace MovieShare.Application.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IConfiguration _configuration;

		public AuthenticationService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GetTokenString(UserDto userDto, TimeSpan expirationPeriod)
		{
			var encodedSecret = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"] ?? string.Empty);
			var secretKey = new SymmetricSecurityKey(encodedSecret);

			var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
			var claims = new List<Claim>
			{
				new(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
				new(ClaimTypes.Name, userDto.Username),
				new(ClaimTypes.Email, userDto.Email)
			};

			var tokenOptions = new JwtSecurityToken(
				_configuration["Jwt:Issuer"],
				_configuration["Jwt:Audience"],
				claims,
				expires: DateTime.Now.Add(expirationPeriod),
				signingCredentials: signingCredentials
				);

			return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
		}
	}
}

