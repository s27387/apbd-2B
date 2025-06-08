using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using s27387_B.DTOs;
using s27387_B.Models;
using s27387_B.Repositories;
using s27387_B.Services;

namespace s27387_B.Controllers;


[ApiController]
[Route("api/{controller}")]
public class CustomersController : ControllerBase
{
    private ICustomersService _customersService;

    public CustomersController(ICustomersService customersService)
    {
        this._customersService = customersService;
    }

    [HttpGet("{customerId:int}/purchases")]
    public async Task<IActionResult> GetCustomerAsync([FromRoute] int customerId)
    {
        var response = await _customersService.GetCustomerWithPurchasesAsync(customerId);
        
        return Ok(response);
    }
}