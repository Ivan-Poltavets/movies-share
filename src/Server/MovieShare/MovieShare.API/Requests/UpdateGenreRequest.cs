using System;
namespace MovieShare.API.Requests
{
	public class UpdateGenreRequest
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

