// MatchChat.Application/Services/IAuthService.cs
using MatchChat.Core.Models.Auth;

namespace MatchChat.Application.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }
}