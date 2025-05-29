using Domain.ApiResponse;
using Domain.DTOs.CustomerDto;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CustomerController(CustomerService customerService)
{
    [HttpGet]
    public async Task<Response<List<GetCustomerDto>>> GetAllCustomerAsync()
    {
        return await customerService.GetAllCustomerAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
    {
        return await customerService.CreateCustomerAsync(createCustomerDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCustomerAsync(Guid Id, UpdateCustomerDto updateCustomerDto)
    {
        return await customerService.UpdateCustomerAsync(Id, updateCustomerDto);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCustomerWithIdAsync(int Id)
    {
        return await customerService.DeleteCustomerWithIdAsync(Id);
    }
}