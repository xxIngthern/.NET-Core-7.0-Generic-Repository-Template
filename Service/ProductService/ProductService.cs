using Core.Repository;
using Entity;

namespace Service.ProductService;

public class ProductService:BaseService<Product>, IProductService<Product>
{
    public ProductService(IRepository<Product> repository) : base(repository)
    {
    }
}