namespace WebApplication3.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; } 
        public string TrailerUrl { get; set; }
        public List<Actor>? Actors { get; set; }
        public int Year { get; set; }
        public string PosterUrl { get; set; }
    }

}
