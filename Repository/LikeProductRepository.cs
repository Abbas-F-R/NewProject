using dotnet.Interface;

namespace dotnet.Repository;

public class LikeProductRepository: GenericRepository<LikeProduct, Guid> , ILikeProductRepository
{
    public LikeProductRepository(DatabaseContext context, IMapper mapper): base(context ,mapper)
    {
        
    }
    
}