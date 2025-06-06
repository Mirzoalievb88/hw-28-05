namespace Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    //navigations
    public List<OrderDetail> OrderDetails { get; set; }
}