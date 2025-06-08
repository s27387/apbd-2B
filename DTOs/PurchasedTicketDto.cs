namespace s27387_B.DTOs;
public class PurchasedTicketDto
{
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public TicketDto Ticket { get; set; }
    public ConcertDto Concert { get; set; }
}