using Microsoft.EntityFrameworkCore;
using Products.Persistence.Models;

namespace Products.Persistence;


public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;

}