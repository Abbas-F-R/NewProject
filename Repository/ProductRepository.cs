using dotnet.Interface;

namespace dotnet.Repository;

public class ProductRepository: GenericRepository<Product, Guid> , IProductRepository
{
    public ProductRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
        
    }
    
}