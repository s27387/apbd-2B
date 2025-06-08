using System.ComponentModel.DataAnnotations;

namespace s27387_B.Models;
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
    
    public ICollection<PurchasedTicket> PurchasedTickets { get; set; }
}