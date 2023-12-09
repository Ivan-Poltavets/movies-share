namespace MovieShare.API.Requests.Review
{
    public class UpdateReviewRequest
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateTimeCreated { get; set; }
    }
}
