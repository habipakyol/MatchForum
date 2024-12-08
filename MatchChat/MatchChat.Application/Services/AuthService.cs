using MatchChat.Core.Entities;
using MatchChat.Core.Interfaces;
using MatchChat.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            // Email ve nickname kontrolü
            if (await _userRepository.GetByEmailAsync(request.Email) != null)
                throw new InvalidOperationException("Email already exists");

            if (await _userRepository.GetByNicknameAsync(request.Nickname) != null)
                throw new InvalidOperationException("Nickname already exists");

            // Şifre hash'leme ve kullanıcı oluşturma
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email.ToLower(),
                Nickname = request.Nickname,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName,
                FavoriteTeam = request.FavoriteTeam,
                CreatedAt = DateTime.UtcNow,
                IsEmailVerified = false,
                Level = 1,
                MessageCount = 0
            };

            var success = await _userRepository.CreateAsync(user);
            if (!success)
                throw new InvalidOperationException("Failed to create user");

            return new AuthResponse
            {
                Token = _jwtService.GenerateToken(user),
                Email = user.Email,
                Nickname = user.Nickname
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new InvalidOperationException("Invalid email or password");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new InvalidOperationException("Invalid email or password");

            return new AuthResponse
            {
                Token = _jwtService.GenerateToken(user),
                Email = user.Email,
                Nickname = user.Nickname
            };
        }
    }
}
