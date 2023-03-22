using Core.Entity;
using Core.Repository;
using Core.Service;

namespace Service;

public class BaseService<TEntity>: IService<TEntity> where TEntity:class,IEntity,new()
{
    private readonly IRepository<TEntity> _repository;

    protected BaseService(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public Task<TEntity> AddAsync(TEntity entity)
    {
        _repository.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
       _repository.Update(entity);
       return Task.FromResult(entity);
    }

    public Task<bool> DeleteAsync(TEntity entity)
    {
        _repository.Delete(entity);
        return Task.FromResult(true);
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var result =await  _repository.GetByIdAsync(id);
        return result;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        return result;
    }
}