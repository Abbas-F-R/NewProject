namespace dotnet.Repository;

public class VehicleRepository : GenericRepository<Vehicle, Guid> , IVehicleRepository
{
    public VehicleRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
        
    }
  
}