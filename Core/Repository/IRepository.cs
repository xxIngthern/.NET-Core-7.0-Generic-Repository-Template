namespace Core.Repository;

public interface IRepository<T>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id, bool isDeleted = false);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync(T entity);
}