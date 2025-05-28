using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OrderController(OrderService orderService)
{
    [HttpGet]
    public async Task<Response<List<Order>>> GetAllOrderAsync()
    {
        return await orderService.GetAllOrderAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateOrderAsync(Order order)
    {
        return await orderService.CreateOrderAsync(order);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateOrderAsync(Order order)
    {
        return await orderService.UpdateOrderAsync(order);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteOrderWithIdAsync(int Id)
    {
        return await orderService.DeleteOrderWithIdAsync(Id);
    }
}