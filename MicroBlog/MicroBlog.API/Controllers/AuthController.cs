
using MicroBlog.Domain.Dtos;
using MicroBlog.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroBlog.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var token = await authService.RegisterAsync(request);
        return token == null ? BadRequest("Registration failed") : Ok(new { Token = token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await authService.LoginAsync(request);
        return token == null ? Unauthorized() : Ok(new { Token = token });
    }
}
