using Core.Repository;
using Entity;
using Repository.CategoryRepository;
using Repository.ProductRepository;

namespace Service.CategoryService;

public class CategoryService:ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> AddAsync(Category entity)
    {
       _repository.Add(entity);
       return entity;
    }

    public async Task<Category> UpdateAsync(Category entity)
    {
        _repository.Update(entity);
        return entity;
    }

    public async Task<bool> DeleteAsync(Category entity)
    {
        _repository.Delete(entity);
        return true;
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities;
    }
}