using Core.Repository;
using Entity;

namespace Service.CategoryService;

public class CategoryService:BaseService<Category>, ICategoryService<Category>
{
    public CategoryService(IRepository<Category> repository) : base(repository)
    {
    }
}