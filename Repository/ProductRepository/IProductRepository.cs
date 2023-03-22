using Core.Entity;
using Core.Repository;

namespace Repository.ProductRepository;

public interface IProductRepository<TEntity> : IRepository<TEntity> where TEntity:class,IEntity, new()
{
    
}