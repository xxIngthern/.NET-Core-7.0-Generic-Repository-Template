using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository.CategoryRepository;

public class CategoryRepository: BaseRepository<Category>, ICategoryRepository<Category>
{
    public CategoryRepository(BaseContext context, DbSet<Category> dbSet) : base(context, dbSet)
    {
    }
}