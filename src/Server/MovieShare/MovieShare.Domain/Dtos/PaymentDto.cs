using MovieShare.Domain.Enums;

namespace MovieShare.Domain.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime DateTime { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal Price { get; set; }

        public MovieDto Movie { get; set; }
    }
}
