using Products.Persistence.Models;

namespace Products.Persistence;

public interface IRepository<T>
{
    Task<T?> GetById(int id);
    Task<List<T>> GetAll(int? id = null);
    Task Add(T entity);
    void Update(T entity);
    Task Delete(int id);
}