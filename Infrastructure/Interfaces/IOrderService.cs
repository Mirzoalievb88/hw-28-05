using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IOrderService
{
    Task<Response<string>> CreateOrderAsync(Order order);
    Task<Response<List<Order>>> GetAllOrderAsync();
    Task<Response<string>> UpdateOrderAsync(Order order);
    Task<Response<string>> DeleteOrderWithIdAsync(int Id);
    Task<Response<Order>> GetOrderWithIdAsync(int Id);
}