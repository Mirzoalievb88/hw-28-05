using Domain.ApiResponse;
using Domain.DTOs.OrderDTO;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OrderController(OrderService orderService)
{
    [HttpGet]
    public async Task<Response<List<GetOrderDto>>> GetAllOrderAsync()
    {
        return await orderService.GetAllOrderAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        return await orderService.CreateOrderAsync(createOrderDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateOrderAsync(Guid Id, UpdateOrderDto updateOrderDto)
    {
        return await orderService.UpdateOrderAsync(Id, updateOrderDto);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteOrderWithIdAsync(int Id)
    {
        return await orderService.DeleteOrderWithIdAsync(Id);
    }

    [HttpGet]
    public async Task<Response<List<GetCustomerNameAndOrderDate>>> GetCustomerNameAndOrderDate()
    {
        return await orderService.GetCustomerNameAndOrderDate();
    }
}