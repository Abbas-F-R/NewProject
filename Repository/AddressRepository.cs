using dotnet.Interface;

namespace dotnet.Repository;

public class AddressRepository : GenericRepository<Address, Guid> , IAddressRepository
{
    public AddressRepository(DatabaseContext context, IMapper mapper): base(context ,mapper)
    {
        
    }
}