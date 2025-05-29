using Domain.ApiResponse;
using Domain.DTOs.ProductDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<Response<string>> CreateProductAsync(CreateProductDto createProductDto);
    Task<Response<List<GetProductDto>>> GetAllProductAsync();
    Task<Response<string>> UpdateProductAsync(Guid Id, UpdateProductDto updateProductDto);
    Task<Response<string>> DeleteProductWithIdAsync(int Id);
}