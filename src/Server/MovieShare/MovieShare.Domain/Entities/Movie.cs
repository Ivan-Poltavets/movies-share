﻿namespace MovieShare.Domain.Entities
{
	public class Movie
	{
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string? BackdropPath { get; set; } = string.Empty;
        public string OriginalLanguage { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public double Popularity { get; set; }
        public string? PosterPath { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}

