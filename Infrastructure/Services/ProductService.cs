using System.Net;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService(DataContext context) : IProductService
{
    public async Task<Response<string>> CreateProductAsync(Product product)
    {
        await context.Products.AddAsync(product);
        var result = await context.SaveChangesAsync();
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

    public async Task<Response<List<Product>>> GetAllProductAsync()
    {
        var products = await context.Products.ToListAsync();
        if (products == null)
        {
            return new Response<List<Product>>("Products is null", HttpStatusCode.NotFound);
        }
        return new Response<List<Product>>(products, "All Worked");
    }

    public async Task<Response<Product>> GetProductWithIdAsync(int Id)
    {
        var products = await context.Products.FindAsync(Id);
        if (products == null)
        {
            return new Response<Product>("Products is null", HttpStatusCode.NotFound);
        }
        return new Response<Product>(products, "All Worked");
    }

    public async Task<Response<string>> UpdateProductAsync(Product product)
    {
        var products = await context.Products.FindAsync(product.Id);
        if (products == null)
        {
            return new Response<string>("Products is null", HttpStatusCode.NotFound);
        }
        products.Name = product.Name;
        products.Description = product.Description;
        products.Price = product.Price;

        var result = await context.SaveChangesAsync();
        
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<string>(default, "All Worked");
    }
}