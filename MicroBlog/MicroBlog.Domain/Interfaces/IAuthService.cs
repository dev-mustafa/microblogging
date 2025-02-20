using MicroBlog.Domain.Dtos;

namespace MicroBlog.Domain.Interfaces;

public interface IAuthService
{
    Task<string?> RegisterAsync(RegisterRequest user);
    Task<string?> LoginAsync(LoginRequest login);
}