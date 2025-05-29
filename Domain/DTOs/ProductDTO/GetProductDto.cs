namespace Domain.DTOs.ProductDTO;

public class GetProductDto : CreateProductDto
{
    public Guid Id { get; set; }
}