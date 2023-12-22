namespace MovieShare.Domain.Entities
{
	public class Movie
	{
        public int Id { get; set; }
        public int TmdbId { get; set; }
        public bool Adult { get; set; }
        public string? BackdropPath { get; set; } = string.Empty;
        public string OriginalLanguage { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public double Popularity { get; set; }
        public string? PosterPath { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string VideoPath { get; set; } = string.Empty; 
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public decimal Price { get; set; }
        public long Budget { get; set; }
        public string Homepage { get; set; } = string.Empty;
        public string? ImdbId { get; set; } = string.Empty;
        public long Revenue { get; set; }
        public int Runtime { get; set; }
        public string Tagline { get; set; } = string.Empty;

        public ICollection<MovieGenre> MovieGenres { get; set; }

    }
}
