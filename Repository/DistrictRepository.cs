using dotnet.Interface;

namespace dotnet.Repository;

public class DistrictRepository : GenericRepository<District, Guid> , IDistrictRepository
{
    public DistrictRepository(DatabaseContext context, IMapper mapper): base(context ,mapper)
    {
        
    }
}