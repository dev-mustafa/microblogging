
using MicroBlog.Domain.Entities;

namespace MicroBlog.Domain.Dtos;

public record RegisterRequest
{
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public string Password { get; set; }
    public string? ProfilePictureUrl { get; set; }
}

public record LoginRequest(string Username, string Password);

public class UserDto (User user)
{
    public string Username { get; init; } = user.UserName;
    public string ImageUrl { get; init; } = user.DisplayName;
}