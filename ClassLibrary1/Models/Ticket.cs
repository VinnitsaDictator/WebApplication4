namespace WebApplication3.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Status { get; set; }
    }



}
