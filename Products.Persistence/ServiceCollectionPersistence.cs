using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Products.Persistence.Models;
using Products.Persistence.Repositories;

namespace Products.Persistence;

public static class ServiceCollectionPersistence
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<ProductsDbContext>(options =>
            options.UseInMemoryDatabase("Products"));

        // Add repositories for Product and Review
        services.AddScoped<IRepository<Product>, ProductRepository>();
        services.AddScoped<IRepository<Review>, ReviewRepository>();
    }
}