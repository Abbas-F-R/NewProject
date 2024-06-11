namespace dotnet.DTOs;

public class Auth
{
    public Auth(User user, string token, RefreshToken refreshToken)
    {
        User = user;
        Token = token;
        RefreshToken = refreshToken;
    }

    public User User { get; set; }
    public string Token { get; set; }
    public RefreshToken RefreshToken { get; set; }
    
}