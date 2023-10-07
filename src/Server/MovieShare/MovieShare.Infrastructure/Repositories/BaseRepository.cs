using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Infrastructure.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity>
		where TEntity : class
	{
		protected readonly MovieDbContext _context;
		protected readonly DbSet<TEntity> _dbSet;

		public BaseRepository(MovieDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}

		public async Task<TEntity?> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			var createdEntity = await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
			return createdEntity.Entity;
		}

		public async Task UpdateAsync(TEntity entity)
		{
			_dbSet.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entityToRemove = await _dbSet.FindAsync(id);

			if (entityToRemove != null)
				_dbSet.Remove(entityToRemove);

			await _context.SaveChangesAsync();
		}
	}
}

