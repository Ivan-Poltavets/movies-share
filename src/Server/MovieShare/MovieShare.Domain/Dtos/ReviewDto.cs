namespace MovieShare.Domain.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateTimeCreated { get; set; }
    }
}
