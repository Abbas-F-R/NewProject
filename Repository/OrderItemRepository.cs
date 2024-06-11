using dotnet.Interface;

namespace dotnet.Repository;

public class OrderItemRepository : GenericRepository<OrderItem, Guid> , IOrderItemRepository
{
    public OrderItemRepository(DatabaseContext context, IMapper mapper): base(context ,mapper)
    {
        
    }
    
}