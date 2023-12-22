using MovieShare.Domain.Enums;

namespace MovieShare.Domain.Entities
{
	public class Payment
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int MovieId { get; set; }
		public DateTime DateTime { get; set; }
		public PaymentStatus Status { get; set; }
		public decimal Price { get; set; }

		public Movie Movie { get; set; }
	}
}

