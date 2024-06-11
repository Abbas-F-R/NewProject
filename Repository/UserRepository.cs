using dotnet.Interface;
namespace dotnet.Repository;

public class UserRepository : GenericRepository<User, Guid> , IUserRepository
{
    public UserRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}