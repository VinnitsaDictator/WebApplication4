namespace WebApplication3.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public int FilmId { get; set; } 
        public Film Film { get; set; } 
        public string Hall { get; set; } 
        public decimal Price { get; set; }
    }

}
