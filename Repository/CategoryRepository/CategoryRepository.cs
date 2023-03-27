using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository.CategoryRepository;

public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(BaseContext context) : base(context)
    {
    }
}