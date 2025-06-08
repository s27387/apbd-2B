using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using s27387_B.Models;
using s27387_B.Repositories;

namespace s27387_B.Controllers;


[ApiController]
[Route("[controller]")]
public class CustomerController
{
    private CustomersRepository _customersRepository;

    public CustomerController(CustomersRepository customersRepository)
    {
        this._customersRepository = customersRepository;
    }

    [HttpGet("customerId")]
    public async Task<IActionResult> GetCustomerAsync(int customerId)
    {
        var result = await _customersRepository.GetCustomerWithDetailsAsync(customerId);
        return Ok(result);
    }
}