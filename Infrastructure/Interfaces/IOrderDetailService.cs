using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IOrderDetailService
{
    Task<Response<string>> CreateOrderDetailAsync(OrderDetail orderDetail);
    Task<Response<List<OrderDetail>>> GetAllOrderDetailAsync();
    Task<Response<string>> UpdateOrderDetailAsync(OrderDetail orderDetail);
    Task<Response<string>> DeleteOrderDetailWithIdAsync(int Id);
    Task<Response<OrderDetail>> GetOrderDetailWithIdAsync(int Id);
}