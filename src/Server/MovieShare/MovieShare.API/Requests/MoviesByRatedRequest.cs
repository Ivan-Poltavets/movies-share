namespace MovieShare.API.Requests
{
	public class MoviesByRatedRequest
	{
        public int MinRated { get; set; }
        public int MaxRated { get; set; }
    }
}

