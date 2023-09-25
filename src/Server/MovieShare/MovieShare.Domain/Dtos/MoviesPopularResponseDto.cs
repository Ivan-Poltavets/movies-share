using System;
namespace MovieShare.Domain.Dtos
{
	public class MoviesPopularResponseDto
	{
		public int page { get; set; }
		public List<MovieResponseDto> results { get; set; }
	}
}

