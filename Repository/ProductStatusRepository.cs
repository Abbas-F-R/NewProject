using dotnet.Interface;

namespace dotnet.Repository;

public class ProductStatusRepository : GenericRepository<ProductStatus, Guid> , IProductStatusRepository
{
    public ProductStatusRepository(DatabaseContext context, IMapper mapper): base(context ,mapper)
    {
        
    }
}