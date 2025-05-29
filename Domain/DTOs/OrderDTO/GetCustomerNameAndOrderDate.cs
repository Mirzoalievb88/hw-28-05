using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.OrderDTO;

public class GetCustomerNameAndOrderDate
{
    [Required(ErrorMessage = "This Customer Name cant be null")]
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
}