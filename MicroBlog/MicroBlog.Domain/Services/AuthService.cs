using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Mapster;
using MicroBlog.Domain.Dtos;
using MicroBlog.Domain.Entities;
using MicroBlog.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MicroBlog.Domain.Services;

public class AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration): IAuthService
{
    public async Task<string?> RegisterAsync(RegisterRequest userDto)
    {
        var user = userDto.Adapt<User>();
        user.Email = userDto.Username;
        user.UserName = userDto.Username;

        var result = await userManager.CreateAsync(user, userDto.Password);

        return result.Succeeded ? GenerateJwtToken(user) : null;
    }

    public async Task<string?> LoginAsync(LoginRequest login)
    {
        var user = await userManager.FindByNameAsync(login.Username);
        if (user == null) return null;

        var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);
        return result.Succeeded ? GenerateJwtToken(user) : null;
    }

    private string GenerateJwtToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!);
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName!),
            new Claim("displayName", user.DisplayName)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}