using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace dotnet.Services.AuthService;

public class JwtService(IConfiguration config,IRepositoryWrapper wrapper) : IJwtService
{

    public async Task<(Auth?, string? error)> Register(UserDto request)
    {
        // Check if the username is already taken
        var existingUser = await wrapper.User.Get(u => u.Username == request.Username);
        if (existingUser != null)
            return (null, "Username taken");
    
        string hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            PasswordHash = hashPassword,
            Username = request.Username,
            Role = Role.User,
        };

        // Add user via repository wrapper
        await wrapper.User.Add(user);

        var token = CreateToken(user);
        var auth = new Auth(user.Username, token);

        Console.WriteLine("Auth: " + auth.Token + "\n\n\n\n\n\n\n\n\n" + auth.Username);

        return (auth, null);
    }

    public async Task<(Auth?, string? error)> Login(UserDto request)
    {
        // Check if the user exists and verify password
        var userSaved = await wrapper.User.Get(u => u.Username == request.Username);
        if (userSaved == null) 
            return (null, "User not found");
                
        if (!BCrypt.Net.BCrypt.Verify(request.Password, userSaved.PasswordHash)) 
            return (null, "Wrong password");
        
        var token = CreateToken(userSaved);
        var auth = new Auth(userSaved.Username, token);
        return (auth, null);
    }
    //
    // public async Task<(Auth?, string? error)> Login(UserDto request)
    // {
    //     var userSaved =  ValidateUserAsync(request.Username).Result;
    //     if (userSaved == null) return (null, "User not found  ");
    //
    //     if (!BCrypt.Net.BCrypt.Verify(request.Password, userSaved.PasswordHash)) return (null, "wrong password");
    //     
    //     string token = CreateToken(userSaved);
    //     RefreshToken refreshToken = GenerateRefreshToken();
    //     var auth = new Auth(userSaved, token, refreshToken);
    //     return (auth, null);
    // }

    // public async Task<(Auth?, string? error)> RefreshToken(string refreshToken)
    // {
    //     var user = await _context.Users
    //         .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
    //     if (user == null) return (null, "user not found");
    //     if (user.TokenExpired < DateTime.Now) return (null, "  Refresh Token expired");
    //
    //     var token = CreateToken(user);
    //     // var newRefreshToken = GenerateRefreshToken();
    //     var auth = new Auth(user, token);
    //     return (auth, null);
    // }
    public string CreateToken(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

        var tokenKey = config.GetSection("AppSettings:Token").Value;
        if (string.IsNullOrEmpty(tokenKey))
        {
            throw new InvalidOperationException("Token key is not configured properly.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            // issuer: _config["Jwt:Issuer"],
            // audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }


    // public RefreshToken GenerateRefreshToken()
    // {
    //     var refreshToken = new RefreshToken
    //     {
    //         Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
    //         Expires = DateTime.Now.AddDays(7)
    //     };
    //     return refreshToken;
    // }
    //
   
}