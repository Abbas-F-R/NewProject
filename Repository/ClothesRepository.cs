using dotnet.Interface;
namespace dotnet.Repository;

public class ClothesRepository : GenericRepository<Clothes, Guid> , IClothesRepository
{
    public ClothesRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
        
    }

}