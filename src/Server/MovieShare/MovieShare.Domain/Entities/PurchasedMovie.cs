namespace MovieShare.Domain.Entities
{
	public class PurchasedMovie
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int MovieId { get; set; }
		public DateTime DateTime { get; set; }
		public decimal Price { get; set; }
	}
}

