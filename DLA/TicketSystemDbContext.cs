using Microsoft.EntityFrameworkCore;
using s27387_B.Models;

namespace s27387_B.DLA;

public class TicketSystemDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }


    protected TicketSystemDbContext()
    {
    }

    public TicketSystemDbContext(DbContextOptions<TicketSystemDbContext> options) : base(options)
    {
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Ticket>().HasData(
            new Ticket { TicketId = 3, SerialNumber = "TICKET69", SeatNumber = 18 },
            new Ticket { TicketId = 5,  SerialNumber = "TICKET420", SeatNumber = 22 }
        );

        
        modelBuilder.Entity<Concert>().HasData(
            new Concert{ ConcertId= 40, Name= "Kwiat Jabloni", Date =new DateTime(1985, 3, 12) },
            new Concert { ConcertId = 60, Name = "Taco Hemingway", Date = new DateTime(1992, 7, 23) }
        );

        modelBuilder.Entity<TicketConcert>().HasData(
            new TicketConcert { TicketConcertId = 43, TicketId = 3, ConcertId = 40, Price = 15.99},
            new TicketConcert { TicketConcertId = 65, TicketId = 5, ConcertId = 60, Price = 59.99}
        );
        
        modelBuilder.Entity<PurchasedTicket>().HasData(
            new PurchasedTicket { TicketConcertId = 43, CustomerId = 1, PurchasedDate = new DateTime(2014, 7, 23)},
            new PurchasedTicket { TicketConcertId = 65, CustomerId = 2, PurchasedDate = new DateTime(2018, 8, 21)}
        );
        
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, FirstName = "Dorothy", LastName = "Helbin", PhoneNumber = "111222333"},
            new Customer { CustomerId = 2, FirstName = "David", LastName = "Gryfindor", PhoneNumber = "888777666"},
            new Customer { CustomerId = 3, FirstName = "Albus", LastName = "Slytherin"}
        );
    }
}