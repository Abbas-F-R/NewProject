namespace dotnet.DTOs;

public class Auth
{
    public string? Username { get; set; } 
    public string? Token { get; set; }
    public Auth(string username, string token)
    {
        Username = username;
        Token = token;
    }
}