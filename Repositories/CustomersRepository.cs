using Microsoft.EntityFrameworkCore;
using s27387_B.DLA;
using s27387_B.DTOs;
using s27387_B.Models;

namespace s27387_B.Repositories;

public class CustomersRepository : ICustomersRepository
{
    private readonly TicketSystemDbContext _dbContext;

    public CustomersRepository(TicketSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CustomerExistsAsync(int cusomerId)
    {
        return await _dbContext.Customers.AnyAsync(c => c.CustomerId == cusomerId);
    }
    
    public async Task<Customer> GetOrAddCustomerAsync(Customer customer)
    {
        var existingCustomer = await _dbContext.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == customer.CustomerId
                                      && c.FirstName == customer.FirstName
                                      && c.LastName == customer.LastName
                                      && c.PhoneNumber == customer.PhoneNumber);
        if (existingCustomer != null)
        {
            return existingCustomer;
        }

        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }
    
    public async Task AddPurchasedTicketsAsync(Customer customer, Purchases purchases)
    {

        foreach (Purchase purchase in purchases.purchases)
        {
            _dbContext.Tickets.Add(new Ticket()
            {
                SeatNumber = purchase.SeatNumber,
                SerialNumber = Convert.ToString(purchase.SeatNumber)
            });
            var concert = await _dbContext.Concerts.FirstOrDefaultAsync(c => c.Name == purchase.concertName);
            
        }
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<Customer?> GetCustomerWithDetailsAsync(int customerId)
    {
        return await _dbContext.Customers
            .Include(c => c.PurchasedTickets)
            .ThenInclude(pt => pt.TicketConcert)
            .ThenInclude(t => t.Concert)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }
    
}