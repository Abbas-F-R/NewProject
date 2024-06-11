using dotnet.Interface;

namespace dotnet.Repository;

public class GovernorateRepository: GenericRepository<Governorate, Guid> , IGovernorateRepository
{
    public GovernorateRepository(DatabaseContext context, IMapper mapper): base(context ,mapper)
    {
        
    }
}