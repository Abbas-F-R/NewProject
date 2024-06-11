using dotnet.Interface;

namespace dotnet.Repository;

public class CartRepository : GenericRepository<Cart, Guid> , ICartRepository
{
    public CartRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
        
    }
}