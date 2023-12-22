using Microsoft.EntityFrameworkCore;
using MovieShare.Domain.Entities;
using MovieShare.Infrastructure.TypeConfigurations;

namespace MovieShare.Infrastructure
{
	public class MovieDbContext : DbContext
	{
		public MovieDbContext(DbContextOptions<MovieDbContext> options)
			: base(options)
		{

		}

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<MovieGenre> MoviesGenres { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Trade> Trades { get; set; }
		public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//modelBuilder.ApplyConfiguration(new MovieGenresTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

