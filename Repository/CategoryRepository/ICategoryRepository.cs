using Core.Entity;
using Core.Repository;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository.CategoryRepository;

public interface ICategoryRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity, new()
{
}