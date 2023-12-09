using MovieShare.Domain.Entities;

namespace MovieShare.Domain.Interfaces
{
	public interface IUserRepository : IBaseRepository<User>
	{
        Task<User> GetByLoginAndPasswordHashAsync(string login, string passwordHash);
        Task<User> GetByLoginAsync(string login);
        Task<bool> IsUserExistAsync(string username, string email);
    }
}

