using System.Data.Entity;
using Products.Persistence.Models;

namespace Products.Persistence.Repositories;

public class ProductRepository : IRepository<Product>
{
    private readonly ProductsDbContext _context;

    public ProductRepository(ProductsDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetById(int id)
    {
        var result = await _context.Products.FindAsync(id);
        return result;
    }

    public Task<List<Product>> GetAll(int? id = null)
    {
        return _context.Products.ToListAsync();
    }

    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public async Task Delete(int id)
    {
        var product = await this.GetById(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}