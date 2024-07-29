namespace dotnet.DTOs;

public class Auth
{
    public Auth(User user, string token)
    {
        User = user;
        Token = token;
    }

    public User User { get; set; }
    public string Token { get; set; }
    
}