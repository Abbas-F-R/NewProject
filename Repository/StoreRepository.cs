using dotnet.Interface;

namespace dotnet.Repository;

public class StoreRepository : GenericRepository<Store, Guid> , IStoreRepository
{
    public StoreRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
        
    }
}