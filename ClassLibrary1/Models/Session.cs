using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int FilmId { get; set; }

        [Required]
        [StringLength(100)]
        public string Hall { get; set; }

        [Required]
        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }

        public Film Film { get; set; }
    }

}
