using System.Net;
using Domain.ApiResponse;
using Domain.DTOs.ProductDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService(DataContext context) : IProductService
{
    public async Task<Response<string>> CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = new Product
        {
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Price = createProductDto.Price,
        };
        var result = await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<string>> DeleteProductWithIdAsync(int Id)
    {
        var products = await context.Products.FindAsync(Id);
        if (products == null)
        {
            return new Response<string>("product is null", HttpStatusCode.NotFound);
        }
        context.Products.Remove(products);
        await context.SaveChangesAsync();
        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<List<GetProductDto>>> GetAllProductAsync()
    {
        var product = await context.Products
        .Select(product => new GetProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
        }).ToListAsync(); 

        if (product == null)
        {
            return new Response<List<GetProductDto>>("Customer is null", HttpStatusCode.NotFound);
        }
        return new Response<List<GetProductDto>>(product, "All Worked");
    }

    public async Task<Response<string>> UpdateProductAsync(Guid Id, UpdateProductDto updateProductDto)
    {
        var product = await context.Products
            .Where(p => p.Id == Id)
            .Select(p => p)
            .FirstOrDefaultAsync();
        if (product == null)
        {
            return new Response<string>("Customer by this Id not Found", HttpStatusCode.NotFound);
        }

        product.Name = updateProductDto.Name;
        product.Description = updateProductDto.Description;
        product.Price = updateProductDto.Price;

        await context.SaveChangesAsync();
        return new Response<string>(default, "All Worked");
    }
}