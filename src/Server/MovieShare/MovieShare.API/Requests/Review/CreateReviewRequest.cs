namespace MovieShare.API.Requests.Review
{
    public class CreateReviewRequest
    {
        public int MovieId { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; }
    }
}
