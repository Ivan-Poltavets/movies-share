﻿namespace MovieShare.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}