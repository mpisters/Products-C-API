using System.Data.Entity;
using Products.Persistence.Models;

namespace Products.Persistence.Repositories;

public class ReviewRepository : IRepository<Review>
{
    private readonly ProductsDbContext _context;

    public ReviewRepository(ProductsDbContext context)
    {
        _context = context;
    }

    public async Task<Review?> GetById(int id)
    {
        var result = await _context.Reviews.FindAsync(id);
        return result;
    }

    public Task<List<Review>> GetAll(int? id = null)
    {
        if (id != null)
        {
            return _context.Reviews.Where(x => x.Id == id).ToListAsync();
        }
        return _context.Reviews.ToListAsync();
    }

    public async Task Add(Review review)
    {
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
    }

    public void Update(Review review)
    {
        _context.Reviews.Update(review);
        _context.SaveChanges();
    }

    public async Task Delete(int id)
    {
        var review = await GetById(id);
        if (review != null)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}