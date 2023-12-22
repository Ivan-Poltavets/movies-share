using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;

namespace MovieShare.Application.Services.Interfaces
{
	public interface IUserService
	{
        Task<UserDto> CreateAsync(UserDto userDto);
        Task<UserDto> GetByLoginAndPassword(string login, string password);
        Task<UserDto> GetUserById(int id);
    }
}

