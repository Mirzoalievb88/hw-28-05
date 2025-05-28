using System.Net;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class OrderService(DataContext context) : IOrderService
{
    public async Task<Response<string>> CreateOrderAsync(Order order)
    {
        await context.Orders.AddAsync(order);
        var result = await context.SaveChangesAsync();
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<string>> DeleteOrderWithIdAsync(int Id)
    {
        var result = await context.Orders.FindAsync(Id);
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        context.Orders.Remove(result);
        await context.SaveChangesAsync();
        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<List<Order>>> GetAllOrderAsync()
    {
        var orders = await context.Orders.ToListAsync();
        if (orders == null)
        {
            return new Response<List<Order>>("Orders is null", HttpStatusCode.NotFound);
        }
        return new Response<List<Order>>(orders, "All Worked");
    }

    public async Task<Response<Order>> GetOrderWithIdAsync(int Id)
    {
        var orders = await context.Orders.FindAsync(Id);
        if (orders == null)
        {
            return new Response<Order>("Orders not found", HttpStatusCode.NotFound);
        }
        return new Response<Order>(orders, "All Worked");
    }

    public async Task<Response<string>> UpdateOrderAsync(Order order)
    {
        var orders = await context.Orders.FindAsync(order.Id);
        if (orders == null)
        {
            return new Response<string>("Order not Found", HttpStatusCode.NotFound);
        }
        orders.CustomerId = order.CustomerId;
        orders.OrderDate = order.OrderDate;
        orders.TotalAmount = order.TotalAmount;

        var result = await context.SaveChangesAsync();
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<string>(default, "All Worked");
    }
}