using s27387_B.DTOs;
using s27387_B.Repositories;
using s27387_B.Services;

public class CustomersService : ICustomersService
{
    private readonly ICustomersRepository _customerRepository;

    public CustomersService(ICustomersRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }
    
    public async Task<CustomerPurchasesDto?> GetCustomerWithPurchasesAsync(int customerId)
    {
        var customer = await _customerRepository.GetCustomerWithPurchasesAsync(customerId);
        
        var customerPurchasesDto = new CustomerPurchasesDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = customer.PurchasedTickets.Select(pt => new PurchasedTicketDto
            {
                Date = pt.PurchasedDate,
                Price = pt.TicketConcert.Price,
                Ticket = new TicketDto
                {
                    Serial = pt.TicketConcert.Ticket.SerialNumber,
                    SeatNumber = pt.TicketConcert.Ticket.SeatNumber
                },
                Concert = new ConcertDto
                {
                    Name = pt.TicketConcert.Concert.Name,
                    Date = pt.TicketConcert.Concert.Date
                }
            }).ToList()
        };
        
        return customerPurchasesDto;
    }
}