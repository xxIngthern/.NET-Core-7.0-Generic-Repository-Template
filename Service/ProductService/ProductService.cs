using Azure.Core;
using Core.Repository;
using Entity;
using Repository.ProductRepository;

namespace Service.ProductService;

public class ProductService:IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> AddAsync(Product entity)
    {
        _repository.Add(entity);
        return entity;
    }

    public async Task<Product> UpdateAsync(Product entity)
    {
        _repository.Update(entity);
        return entity;
    }

    public async Task<bool> DeleteAsync(Product entity)
    {
        _repository.Delete(entity);
        return true;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}