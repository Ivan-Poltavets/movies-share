namespace MovieShare.Domain.Dtos.Tmdb
{
    public class MovieDetailsResponseDto
    {
        public int id { get; set; }
        public long budget { get; set; }
        public string homepage { get; set; } = string.Empty;
        public string imdb_id { get; set; } = string.Empty;
        public long revenue { get; set; }
        public int runtime { get; set; }
        public string tagline { get; set; } = string.Empty;
    }
}
