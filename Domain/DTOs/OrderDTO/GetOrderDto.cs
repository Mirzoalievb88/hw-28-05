using Domain.DTOs.OrderDTO;
namespace Domain.DTOs.OrderDTO;

public class GetOrderDto : CreateOrderDto
{
    public Guid Id { get; set; }
}