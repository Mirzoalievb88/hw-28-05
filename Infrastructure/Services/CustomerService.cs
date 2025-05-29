using System.Data.Common;
using System.Net;
using Domain.ApiResponse;
using Domain.DTOs.CustomerDto;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CustomerService(DataContext context) : ICustomerService
{
    public async Task<Response<string>> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
    {
        var customer = new Customer
        {
            Name = createCustomerDto.Name,
            Email = createCustomerDto.Email,
            RegisteredOn = createCustomerDto.RegisteredOn,
        };
        var result = await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<string>> DeleteCustomerWithIdAsync(int Id)
    {
        var customer = await context.Customers.FindAsync(Id);
        if (customer == null)
        {
            return new Response<string>("Customer not Found", HttpStatusCode.NotFound);
        }

        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
        return new Response<string>(default, "All Worked");

    }

    public async Task<Response<List<GetCustomerDto>>> GetAllCustomerAsync()
    {
        var customer = await context.Customers
        .Select(customer => new GetCustomerDto()
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            RegisteredOn = customer.RegisteredOn,
        }).ToListAsync(); 

        if (customer == null)
        {
            return new Response<List<GetCustomerDto>>("Customer is null", HttpStatusCode.NotFound);
        }
        return new Response<List<GetCustomerDto>>(customer, "All Worked");
    }

    public async Task<Response<string>> UpdateCustomerAsync(Guid Id, UpdateCustomerDto updateCustomerDto)
    {
        var customer = await context.Customers
            .Where(c => c.Id == Id)
            .Select(c => c)
            .FirstOrDefaultAsync();
        if (customer == null)
        {
            return new Response<string>("Customer by this Id not Found", HttpStatusCode.NotFound);
        }

        customer.Name = updateCustomerDto.Name;
        customer.Email = updateCustomerDto.Email;
        customer.RegisteredOn = updateCustomerDto.RegisteredOn;

        await context.SaveChangesAsync();
        return new Response<string>(default, "All Worked");
    }
}  