namespace Core.Service;

public interface IService<T>
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
}