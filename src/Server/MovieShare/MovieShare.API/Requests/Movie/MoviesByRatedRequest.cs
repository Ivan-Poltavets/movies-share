namespace MovieShare.API.Requests.Movie
{
    public class MoviesByRatedRequest
    {
        public int MinRated { get; set; }
        public int MaxRated { get; set; }
    }
}

