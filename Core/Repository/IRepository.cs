using Core.Entity;

namespace Core.Repository;

public interface IRepository<T> where T:class, IEntity, new()
{
    void Add(T entity);
    void Update(string id, T entity);
    void Delete(string id);
    Task<T> GetByIdAsync(string id);
    Task<List<T>> GetAllAsync();
}