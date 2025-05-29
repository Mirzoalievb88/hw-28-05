using Domain.DTOs.CustomerDto;
namespace Domain.DTOs.CustomerDto;

public class GetCustomerDto : CreateCustomerDto
{
    public Guid Id { get; set; }
}