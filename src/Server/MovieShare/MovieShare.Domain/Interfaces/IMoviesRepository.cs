using MovieShare.Domain.Entities;

namespace MovieShare.Domain.Interfaces
{
    public interface IMoviesRepository : IBaseRepository<Movie>
	{
        Task<List<Movie>> GetByPopularityAsync(int page, int itemsCount);
        Task<List<Movie>> GetByTopRatedAsync(int page, int itemsCount);
        Task<List<Movie>> GetByRatedAsync(int minRated, int maxRated, int page, int itemsCount);
        Task<List<Movie>> GetByGenresAsync(List<Genre> genres, int page, int itemsCount);
    }
}

