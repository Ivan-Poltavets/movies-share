using MovieShare.Domain.Enums;

namespace MovieShare.Domain.Entities
{
	public class Share
	{
		public int Id { get; set; }
		public int MovieId { get; set; }
		public int RequesterId { get; set; }
		public int ReceiverId { get; set; }
		public DateTime? ShareStarts { get; set; }
		public DateTime? ShareExpires { get; set; }
		public ShareStatus ShareStatus { get; set; } = ShareStatus.WaitingForResponse;
	}
}

