using MovieShare.Domain.Dtos;

namespace MovieShare.Application.Services.Interfaces
{
	public interface IAuthenticationService
	{
        string GetTokenString(UserDto userDto, TimeSpan expirationPeriod);
        string GetAdminTokenString(UserDto userDto, TimeSpan expirationPeriod);
    }
}

