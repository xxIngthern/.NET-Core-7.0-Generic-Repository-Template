using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository.ProductRepository;

public class ProductRepository:BaseRepository<Product>,IProductRepository<Product>
{
    public ProductRepository(BaseContext context, DbSet<Product> dbSet) : base(context, dbSet)
    {
    }
}