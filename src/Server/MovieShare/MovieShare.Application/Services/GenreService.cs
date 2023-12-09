using AutoMapper;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;

namespace MovieShare.Application.Services
{
	public class GenreService : IGenreService
	{
		private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<List<GenreDto>> GetAsync()
        {
            var genres = await _genreRepository.GetGenresAsync();
            return _mapper.Map<List<GenreDto>>(genres);
        }

        public async Task<GenreDto> CreateAsync(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            var createdGenre = await _genreRepository.CreateAsync(genre);
            return _mapper.Map<GenreDto>(createdGenre);
        }

        public async Task UpdateAsync(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _genreRepository.UpdateAsync(genre);
        }

        public async Task DeleteAsync(int id)
        {
            await _genreRepository.DeleteAsync(id);
        }
	}
}

