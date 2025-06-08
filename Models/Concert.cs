using System.ComponentModel.DataAnnotations;

namespace s27387_B.Models;

public class Concert
{
    [Key]
    public int ConcertId{ get; set; }
    [Required]
    [MaxLength(100)]
    public string Name{ get; set; }
    [Required]
    public DateTime Date{ get; set; }
    [Required]
    public int AvailableTickets{ get; set; }
    
    public ICollection<TicketConcert> TicketConcerts { get; set; }
}