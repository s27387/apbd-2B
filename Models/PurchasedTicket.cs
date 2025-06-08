using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace s27387_B.Models;

[PrimaryKey(nameof(TicketConcertId), nameof(CustomerId))]
[Table("Purchased_Ticket")]
public class PurchasedTicket
{
    [ForeignKey(nameof(TicketConcertId))]
    public int TicketConcertId { get; set; }
    public TicketConcert TicketConcert{ get; set; }
    
    [ForeignKey(nameof(CustomerId))]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    [Required]
    public DateTime PurchasedDate { get; set; }
}