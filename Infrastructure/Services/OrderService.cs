using System.Net;
using System.Text.RegularExpressions;
using Domain.ApiResponse;
using Domain.DTOs.OrderDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class OrderService(DataContext context) : IOrderService
{
    public async Task<Response<string>> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var order = new Order
        {
            CustomerId = createOrderDto.CustomerId,
            OrderDate = createOrderDto.OrderDate,
            
        };
        var result = await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<string>> DeleteOrderWithIdAsync(int Id)
    {
        var order = await context.Orders.FindAsync(Id);
        if (order == null)
        {
            return new Response<string>("Customer not Found", HttpStatusCode.NotFound);
        }

        context.Orders.Remove(order);
        await context.SaveChangesAsync();
        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<List<GetOrderDto>>> GetAllOrderAsync()
    {
        var order = await context.Orders
        .Select(order => new GetOrderDto()
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,

        }).ToListAsync(); 

        if (order == null)
        {
            return new Response<List<GetOrderDto>>("Customer is null", HttpStatusCode.NotFound);
        }
        return new Response<List<GetOrderDto>>(order, "All Worked");
    }

    public async Task<Response<List<GetCustomerNameAndOrderDate>>> GetCustomerNameAndOrderDate()
    {
        var orders = await context.Orders
            .Include(order => order.Customer)
            .Select(order => new GetCustomerNameAndOrderDate()
            {
                CustomerName = order.Customer.Name,
                OrderDate = order.OrderDate,
            }).ToListAsync();

        if (orders == null)
        {
            return new Response<List<GetCustomerNameAndOrderDate>>("Orders is null", HttpStatusCode.NotFound);
        }
        return new Response<List<GetCustomerNameAndOrderDate>>(orders, "All Worked");
    }

    public async Task<Response<string>> UpdateOrderAsync(Guid Id, UpdateOrderDto updateOrderDto)
    {
        var order = await context.Orders
            .Where(o => o.Id == Id)
            .Select(o => o)
            .FirstOrDefaultAsync();
        if (order == null)
        {
            return new Response<string>("Customer by this Id not Found", HttpStatusCode.NotFound);
        }

        order.CustomerId = updateOrderDto.CustomerId;
        order.OrderDate = updateOrderDto.OrderDate;

        await context.SaveChangesAsync();
        return new Response<string>(default, "All Worked");
    }

    public Task<Response<string>> UpdateOrderAsync(int Id, UpdateOrderDto updateOrderDto)
    {
        throw new NotImplementedException();
    }
}