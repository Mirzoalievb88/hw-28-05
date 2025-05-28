using System.Net;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CustomerService(DataContext context) : ICustomerService
{
    public async Task<Response<string>> CreateCustomerAsync(Customer customer)
    {
        await context.Customers.AddAsync(customer);
        var result = context.SaveChangesAsync(); 
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<string>> DeleteCustomerWithIdAsync(int Id)
    {
        var result = await context.Customers.FindAsync(Id);
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        context.Customers.Remove(result);
        await context.SaveChangesAsync();
        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<List<Customer>>> GetAllCustomerAsync()
    {
        var customer = await context.Customers.ToListAsync();
        if (customer == null)
        {
            return new Response<List<Customer>>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<List<Customer>>(customer, "All Worked");
    }

    public async Task<Response<Customer>> GetCustomerWithIdAsync(int Id)
    {
        var result = await context.Customers.FindAsync(Id);
        if (result == null)
        {
            return new Response<Customer>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<Customer>(result, "All Worked");
    }

    public async Task<Response<string>> UpdateCustomerAsync(Customer customer)
    {
        var customers = await context.Customers.FindAsync(customer.Id);
        if (customers == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }

        customers.Name = customer.Name;
        customers.Email = customer.Email;
        customers.RegisteredOn = customer.RegisteredOn;

        var result = await context.SaveChangesAsync();
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<string>(default, "All Worked");
    }
}  