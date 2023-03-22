using Core.Entity;

namespace Core.Repository;

public interface IRepository<T> where T:class, IEntity, new()
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
}