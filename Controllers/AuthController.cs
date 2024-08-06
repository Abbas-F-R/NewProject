using dotnet.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AuthController(IJwtService jwtService) : ControllerBase
{
 
    [HttpPost("register")]
    public async Task<ActionResult<(Auth?, string? error)>> Register(UserDto request) => Ok(await jwtService.Register(request) );
    // {
    //     try
    //     {
    //         var (auth , error) = await _jwtService.Register(request);
    //         await SetRefreshToken(auth.RefreshToken, auth.User);
    //         return Ok(auth.Token);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(new { message = ex.Message });
    //     }
    // }

    [HttpPost("login")]
    public async Task<ActionResult<(Auth?, string? error)>> Login(UserDto request) => Ok(await jwtService.Login(request));
    // {
    //     try
    //     {
    //         var auth = await _jwtService.Login(request);
    //         await SetRefreshToken(auth.RefreshToken, auth.User);
    //         return Ok(auth.Token);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(new { message = ex.Message });
    //     }
    // }

    // [HttpPost("refresh_Token")]
    // public async Task<ActionResult<(Auth?, string? error)>> RefreshToken() => Ok()
    // {
    //     try
    //     {
    //         var refreshToken = Request.Cookies["refreshToken"];
    //         if (string.IsNullOrEmpty(refreshToken))
    //         {
    //             return BadRequest(new { message = "Refresh token is missing" });
    //         }
    //
    //         var auth = await _jwtService.RefreshToken(refreshToken);
    //         await SetRefreshToken(auth.RefreshToken, auth.User);
    //         return Ok(auth.Token);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(new { message = ex.Message });
    //     }
    // }

    // private async Task SetRefreshToken(RefreshToken newRefreshToken, User user)
    // {
    //     var cookieOptions = new CookieOptions
    //     {
    //         HttpOnly = true,
    //         Expires = newRefreshToken.Expires
    //     };
    //     Response.Cookies.Append("RefreshToken", newRefreshToken.Token, cookieOptions);
    //     user.RefreshToken = newRefreshToken.Token;
    //     user.TokenCreated = newRefreshToken.Created;
    //     user.TokenExpired = newRefreshToken.Expires;
    //     await _context.SaveChangesAsync();
    // }
}