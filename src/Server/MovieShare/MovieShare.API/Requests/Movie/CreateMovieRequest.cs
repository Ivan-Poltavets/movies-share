namespace MovieShare.API.Requests.Movie
{
    public class CreateMovieRequest
    {
        public bool Adult { get; set; }
        public string OriginalLanguage { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
