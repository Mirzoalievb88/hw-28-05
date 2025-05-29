using Domain.ApiResponse;
using Domain.DTOs.OrderDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IOrderService
{
    Task<Response<string>> CreateOrderAsync(CreateOrderDto createOrderDto);
    Task<Response<List<GetOrderDto>>> GetAllOrderAsync();
    Task<Response<string>> UpdateOrderAsync(int Id, UpdateOrderDto updateOrderDto);
    Task<Response<string>> DeleteOrderWithIdAsync(int Id);
    Task<Response<List<GetCustomerNameAndOrderDate>>> GetCustomerNameAndOrderDate();
}