using MovieShare.Domain.Entities;
using MovieShare.Domain.Enums;

namespace MovieShare.Domain.Dtos
{
    public class TradeDto
    {
        public int Id { get; set; }
        public int RequesterMovieId { get; set; }
        public int ReceiverMovieId { get; set; }
        public int RequesterId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime? Starts { get; set; }
        public DateTime? Expires { get; set; }
        public TradeStatus Status { get; set; } = TradeStatus.WaitingForResponse;

        public MovieDto RequesterMovie { get; set; }
        public MovieDto ReceiverMovie { get; set; }

        public User Requester { get; set; }
        public User Receiver { get; set; }
    }
}
