using Core.Entity;
using Core.Repository;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository.CategoryRepository;

public interface ICategoryRepository : IRepository<Category>
{
}