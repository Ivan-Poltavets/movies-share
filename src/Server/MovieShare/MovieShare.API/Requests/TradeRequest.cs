namespace MovieShare.API.Requests
{
    public class TradeRequest
    {
        public int RequesterMovieId { get; set; }
        public int ReceiverMovieId { get; set; }
        public int ReceiverId { get; set; }
    }
}
