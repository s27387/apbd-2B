using s27387_B.DTOs;
using s27387_B.Models;

namespace s27387_B.Repositories;

public interface ICustomersRepository
{
     Task<Customer?> GetCustomerWithPurchasesAsync(int customerId);
}