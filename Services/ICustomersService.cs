using s27387_B.DTOs;

namespace s27387_B.Services;

public interface ICustomersService
{
    Task<CustomerPurchasesDto?> GetCustomerWithPurchasesAsync(int customerId);
}