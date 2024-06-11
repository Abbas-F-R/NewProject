using dotnet.Interface;

namespace dotnet.Repository;

public class CartItemRepository : GenericRepository<CartItem, Guid> , ICartItemRepository
{
    public CartItemRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
        
    }
}