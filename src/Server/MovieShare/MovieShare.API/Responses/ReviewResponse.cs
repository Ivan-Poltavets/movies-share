using MovieShare.Domain.Dtos;

namespace MovieShare.API.Responses
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateTimeCreated { get; set; }
        public UserInfoReponse User { get; set; }
    }
}
