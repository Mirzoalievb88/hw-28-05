using Domain.Entities;

namespace Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime RegisteredOn { get; set; }

    //navigations

    public List<Order> Orders { get; set; }
}