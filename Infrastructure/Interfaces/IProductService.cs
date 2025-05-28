using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<Response<string>> CreateProductAsync(Product product);
    Task<Response<List<Product>>> GetAllProductAsync();
    Task<Response<string>> UpdateProductAsync(Product product);
    Task<Response<string>> DeleteProductWithIdAsync(int Id);
    Task<Response<Product>> GetProductWithIdAsync(int Id);
}