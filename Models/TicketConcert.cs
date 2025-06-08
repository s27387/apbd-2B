using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace s27387_B.Models;

[Table("Ticket_Concert")]
public class TicketConcert
{
    [Key]
    public int TicketConcertId{ get; set; }
    
    [ForeignKey(nameof(TicketId))]
    public int TicketId{ get; set; }
    public Ticket Ticket{ get; set; }
    
    [ForeignKey(nameof(ConcertId))]
    public int ConcertId{ get; set; }
    public Concert Concert{ get; set; }
    
    [Required]
    [Precision(10,2)]
    public double Price{ get; set; } 
    
    public ICollection<PurchasedTicket> PurchasedTickets { get; set; }
}