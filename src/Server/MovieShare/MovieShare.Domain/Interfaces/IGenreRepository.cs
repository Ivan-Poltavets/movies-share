using MovieShare.Domain.Entities;

namespace MovieShare.Domain.Interfaces
{
	public interface IGenreRepository : IBaseRepository<Genre>
	{
        Task<List<Genre>> GetGenresAsync();
    }
}

