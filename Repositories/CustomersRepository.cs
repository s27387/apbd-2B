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
    public async Task<Customer?> GetCustomerWithPurchasesAsync(int customerId)
    {
        var customer = await _dbContext.Customers
            .Include(c => c.PurchasedTickets)
            .ThenInclude(pt => pt.TicketConcert)
            .ThenInclude(tc => tc.Concert)
            .Include(c => c.PurchasedTickets)
            .ThenInclude(pt => pt.TicketConcert)
            .ThenInclude(tc => tc.Ticket)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (customer == null)
            return null;

        return customer;
    }
    
}