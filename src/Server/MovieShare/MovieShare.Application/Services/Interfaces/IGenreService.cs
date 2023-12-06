using MovieShare.Domain.Dtos;

namespace MovieShare.Application.Services.Interfaces
{
	public interface IGenreService
	{
        Task<List<GenreDto>> GetAsync();
        Task<GenreDto> CreateAsync(GenreDto genreDto);
        Task UpdateAsync(GenreDto genreDto);
        Task DeleteAsync(int id);
    }
}

