using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController(ProductService productService)
{
    [HttpGet]
    public async Task<Response<List<Product>>> GetAllProductAsync()
    {
        return await productService.GetAllProductAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateProductAsync(Product product)
    {
        return await productService.CreateProductAsync(product);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateProductAsync(Product product)
    {
        return await productService.UpdateProductAsync(product);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteProductWithIdAsync(int Id)
    {
        return await productService.DeleteProductWithIdAsync(Id);
    }
}