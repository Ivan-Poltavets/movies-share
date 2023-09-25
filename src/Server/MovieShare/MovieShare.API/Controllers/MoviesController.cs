using Microsoft.AspNetCore.Mvc;
using MovieShare.Infrastructure;

namespace MovieShare.API.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Movies
                .Take(20));
        }

        [Route("genres")]
        [HttpGet]
        public IActionResult GetGenre()
        {
            return Ok(_context.Genres.ToList());
        }

        [Route("moviesgenres")]
        [HttpGet]
        public IActionResult GetMoviesGenres()
        {
            return Ok(_context.MoviesGenres.Take(100).ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

