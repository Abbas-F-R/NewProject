using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using dotnet.Services.AuthService;
using Microsoft.IdentityModel.Tokens;


namespace dotnet.Services.AuthService;

public class JwtService : IJwtService
{
    private readonly IConfiguration _config;
    private readonly DatabaseContext _context;

    public JwtService(IConfiguration config, DatabaseContext context)
    {
        _config = config;
        _context = context;
    }

    public async Task<Auth> Register(UserDto request)
    {
        string hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var userSaved = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (userSaved != null)
        {
            throw new ArgumentException(" username taken");
        }

        var user = new User
        {
            PasswordHash = hashPassword,
            Username = request.Username,
            Role = Role.Admin,
        };
        _context.Add(user);
        await _context.SaveChangesAsync();

        string token = CreateToken(user);
        RefreshToken refreshToken = GenerateRefreshToken();
        var auth = new Auth(user, token, refreshToken);
        return auth;
    }

    public async Task<Auth> Login(UserDto request)
    {
        var user = await _context.Users.FirstAsync(u => u.Username == request.Username);
        if (user.Equals(null))
        {
            throw new EntityNotFoundException("user not found");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new Exception("Wrong password.");
        }

        string token = CreateToken(user);
        RefreshToken refreshToken = GenerateRefreshToken();
        var auth = new Auth(user, token, refreshToken);
        return auth;
    }

    public async Task<Auth> RefreshToken(string refreshToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user == null) throw new EntityNotFoundException("user not found");
        if (user.TokenExpired < DateTime.Now) throw new UnauthorizedAccessException("  Refresh Token expired");

        var token = CreateToken(user);
        var newRefreshToken = GenerateRefreshToken();
        var auth = new Auth(user, token, newRefreshToken);
        return auth;
    }
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

        var tokenKey = _config.GetSection("AppSettings:Token").Value;
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


    public RefreshToken GenerateRefreshToken()
    {
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.Now.AddDays(7)
        };
        return refreshToken;
    }
}