using dotnet.Services.AuthService;
using dotnet.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IJwtService _jwtService;

    public AuthController(DatabaseContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request)
    {
        try
        {
            var auth = await _jwtService.Register(request);
            await SetRefreshToken(auth.RefreshToken, auth.User);
            return Ok(auth.Token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(UserDto request)
    {
        try
        {
            var auth = await _jwtService.Login(request);
            await SetRefreshToken(auth.RefreshToken, auth.User);
            return Ok(auth.Token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("refresh_Token")]
    public async Task<ActionResult<string>> RefreshToken()
    {
        try
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return BadRequest(new { message = "Refresh token is missing" });
            }

            var auth = await _jwtService.RefreshToken(refreshToken);
            await SetRefreshToken(auth.RefreshToken, auth.User);
            return Ok(auth.Token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    private async Task SetRefreshToken(RefreshToken newRefreshToken, User user)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = newRefreshToken.Expires
        };
        Response.Cookies.Append("RefreshToken", newRefreshToken.Token, cookieOptions);
        user.RefreshToken = newRefreshToken.Token;
        user.TokenCreated = newRefreshToken.Created;
        user.TokenExpired = newRefreshToken.Expires;
        await _context.SaveChangesAsync();
    }
}