using System.ComponentModel.DataAnnotations;
using WebApplication3.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [StringLength(500)]
    public string? Biography { get; set; }
    public DateTime? BirthDate { get; set; }
    public List<Film>? Films { get; set; }
}

