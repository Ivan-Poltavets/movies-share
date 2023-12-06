using Microsoft.AspNetCore.Mvc;
using MovieShare.Application.Services.Interfaces;

namespace MovieShare.API.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly ITmdbDataService _tmdbDataService;
        private readonly IConfiguration _configuration;

        public ImagesController(ITmdbDataService tmdbDataService, IConfiguration configuration)
        {
            _tmdbDataService = tmdbDataService;
            _configuration = configuration;
        }

        [HttpGet("{imagePath}")]
        public async Task<IActionResult> GetImage(string imagePath)
        {
            var content = await _tmdbDataService.GetMovieImage(imagePath);
            var extension = Path.GetExtension(imagePath);
            return File(content, GetImageMimeTypeFromFileExtension(extension));
        }

        [HttpGet("users/{imagePath}")]
        public async Task<IActionResult> GetUserImage(string imagePath)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _configuration["FileStoragePath"], imagePath);
            var bytes = await System.IO.File.ReadAllBytesAsync(path);
            if (bytes is null)
            {
                throw new Exception("Image not found");
            }
            var extension = Path.GetExtension(imagePath);
            return File(bytes, GetImageMimeTypeFromFileExtension(extension));
        }

        private string GetImageMimeTypeFromFileExtension(string extension)
        {
            string mimetype = extension switch
            {
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".bmp" => "image/bmp",
                ".tiff" => "image/tiff",
                ".wmf" => "image/wmf",
                ".jp2" => "image/jp2",
                ".svg" => "image/svg+xml",
                _ => "application/octet-stream",
            };
            return mimetype;
        }
    }
}

