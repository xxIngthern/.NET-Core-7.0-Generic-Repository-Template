using Entity;

namespace Repository.ProductRepository;

public class ProductRepository:BaseRepository<Product>,IProductRepository
{
    public ProductRepository(BaseContext context) : base(context)
    {
    }
}