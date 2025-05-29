using Domain.ApiResponse;
using Domain.DTOs.ProductDTO;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController(ProductService productService)
{
    [HttpGet]
    public async Task<Response<List<GetProductDto>>> GetAllProductAsync()
    {
        return await productService.GetAllProductAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateProductAsync(CreateProductDto createProductDto)
    {
        return await productService.CreateProductAsync(createProductDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateProductAsync(Guid Id, UpdateProductDto updateProductDto)
    {
        return await productService.UpdateProductAsync(Id, updateProductDto);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteProductWithIdAsync(int Id)
    {
        return await productService.DeleteProductWithIdAsync(Id);
    }
}