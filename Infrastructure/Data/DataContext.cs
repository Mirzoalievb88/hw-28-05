using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });

        modelBuilder.Entity<Product>()
            .Property(p => p.Description)
            .IsRequired(true)
            .HasMaxLength(200);
            
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(k => k.OrderId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderDetails)
            .WithOne(m => m.Product)
            .HasForeignKey(p => p.ProductId);
    }
}
