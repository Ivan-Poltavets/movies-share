namespace MovieShare.Domain.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public double Rating { get; set; }
    }
}
