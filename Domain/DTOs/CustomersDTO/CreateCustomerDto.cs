namespace Domain.DTOs.CustomerDto;

public class CreateCustomerDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime RegisteredOn { get; set; }
}