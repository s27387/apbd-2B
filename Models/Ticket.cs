using System.ComponentModel.DataAnnotations;

namespace s27387_B.Models;

public class Ticket
{
    [Key]
    public int TicketId{ get; set; }
    [Required]
    [MaxLength(50)]
    public string SerialNumber{ get; set; }
    [Required]
    public int SeatNumber{ get; set; }
    
    public ICollection<TicketConcert> TicketConcerts { get; set; }
}