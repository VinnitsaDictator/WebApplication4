namespace WebApplication3.DBcontext.WebCinema.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using WebApplication3.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var str = "Server=(localdb)\\mssqllocaldb;Database=WebApplication3;Trusted_Connection=True;MultipleActiveResultSets=true";
                optionsBuilder.UseSqlServer(str);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(
                new Film { Id = 1, Title = "Inception", Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", Genre = "Sci-Fi", Duration = 148, TrailerUrl = "https://www.youtube.com/watch?v=YoHD9XEInc0", Year = 2010, PosterUrl = "https://example.com/inception-poster.jpg" },
                new Film { Id = 2, Title = "The Matrix", Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", Genre = "Sci-Fi", Duration = 136, TrailerUrl = "https://www.youtube.com/watch?v=vKQi3bBA1y8", Year = 1999, PosterUrl = "https://example.com/matrix-poster.jpg" }
               
            );

            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "Leonardo DiCaprio", BirthDate = new DateTime(1974, 11, 11) },
                new Actor { Id = 2, Name = "Joseph Gordon-Levitt", BirthDate = new DateTime(1981, 2, 17) },
                new Actor { Id = 3, Name = "Keanu Reeves", BirthDate = new DateTime(1964, 9, 2) },
                new Actor { Id = 4, Name = "Carrie-Anne Moss", BirthDate = new DateTime(1967, 8, 21) }
               
            );

            modelBuilder.Entity<Session>().HasData(
                new Session { Id = 1, Date = new DateTime(2023, 10, 1, 19, 0, 0), FilmId = 1, Hall = "Main Hall", Price = 12.99m },
                new Session { Id = 2, Date = new DateTime(2023, 10, 2, 19, 0, 0), FilmId = 2, Hall = "Main Hall", Price = 12.99m }
               
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Login = "johndoe", Password = "password123" },
                new User { Id = 2, Name = "Jane Smith", Login = "janesmith", Password = "password123" }
               
            );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, SessionId = 1, UserId = 1, Status = "Booked" },
                new Ticket { Id = 2, SessionId = 2, UserId = 2, Status = "Booked" }
              
            );

          
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Actors)
                .WithMany(a => a.Films)
                .UsingEntity(j => j.HasData(
                    new { FilmsId = 1, ActorsId = 1 },
                    new { FilmsId = 1, ActorsId = 2 },
                    new { FilmsId = 2, ActorsId = 3 },
                    new { FilmsId = 2, ActorsId = 4 }
                ));
        }
    }
}


