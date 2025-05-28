using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class OrderDetail
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }

    [Required(ErrorMessage = "Quantity cant be null")]
    public int Quantity { get; set; }


    //navigations
    public decimal Price { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}