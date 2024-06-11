using dotnet.Interface;

namespace dotnet.Repository;

public class CityRepository : GenericRepository<City, Guid> , ICityRepository
{
    public CityRepository(DatabaseContext context, IMapper mapper): base(context ,mapper)
    {
        
    }
    
}