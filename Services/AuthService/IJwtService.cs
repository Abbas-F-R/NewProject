
namespace dotnet.Services.AuthService;

public interface IJwtService
{
    string CreateToken(User user);
    Task<Auth> Register(UserDto request);
    RefreshToken GenerateRefreshToken();
    Task<Auth> Login(UserDto request);
    Task<Auth> RefreshToken(string refreshToken);
}