using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(MovieDbContext context) : base(context)
		{
		}

		public async Task<User> GetByLoginAsync(string login)
		{
			var user = await _dbSet.FirstOrDefaultAsync(x => x.Username == login || x.Email == login);

			return user;
		}

		public async Task<User> GetByLoginAndPasswordHashAsync(string login, string passwordHash)
		{
			var user = await _dbSet
				.Where(x => (x.Username == login || x.Email == login) && x.PasswordHash == passwordHash)
				.FirstOrDefaultAsync();

			return user;
		}

		public async Task<bool> IsUserExistAsync(string username, string email)
		{
			var user = await _dbSet
				.FirstOrDefaultAsync(x => x.Username == username || x.Email == email);
			if(user != null)
				return true;
			return false;
		}
	}
}

