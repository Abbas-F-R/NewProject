
namespace dotnet.Services.AuthService;

public interface IJwtService
{
    string CreateToken(User user);
    Task<(Auth?, string? error)> Register(UserDto request);
    // RefreshToken GenerateRefreshToken();
    Task<(Auth?, string? error)> Login(UserDto request);
    // Task<(Auth?, string? error)> RefreshToken(string refreshToken);
}