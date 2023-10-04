namespace MovieShare.Domain.Dtos
{
	public class MovieDto
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string PosterPath { get; set; } = string.Empty;
		public DateTime? ReleaseDate { get; set; }
	}
}

