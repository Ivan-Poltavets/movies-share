using MovieShare.Domain.Dtos;

namespace MovieShare.Application.Services.Interfaces
{
	public interface IUserService
	{
        Task<UserDto> CreateAsync(UserDto userDto);
        Task<UserDto> GetByLoginAndPassword(string login, string password);
    }
}

