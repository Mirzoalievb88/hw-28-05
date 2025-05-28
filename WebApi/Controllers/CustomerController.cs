using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CustomerController(CustomerService customerService)
{
    [HttpGet]
    public async Task<Response<List<Customer>>> GetAllCustomerAsync()
    {
        return await customerService.GetAllCustomerAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateCustomerAsync(Customer customer)
    {
        return await customerService.CreateCustomerAsync(customer);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCustomerAsync(Customer customer)
    {
        return await customerService.UpdateCustomerAsync(customer);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCustomerWithIdAsync(int Id)
    {
        return await customerService.DeleteCustomerWithIdAsync(Id);
    }
}