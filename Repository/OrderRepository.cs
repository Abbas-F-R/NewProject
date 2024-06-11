using dotnet.Interface;

namespace dotnet.Repository;

public class OrderRepository: GenericRepository<Order, Guid> , IOrderRepository
{
    public OrderRepository(DatabaseContext context, IMapper mapper): base(context ,mapper)
    {
        
    }
    
}