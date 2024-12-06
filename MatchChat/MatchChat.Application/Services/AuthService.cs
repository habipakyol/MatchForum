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
            // Email kontrolü
            if (await _userRepository.GetByEmailAsync(request.Email) != null)
                throw new Exception("Email already exists");

            // Nickname kontrolü
            if (await _userRepository.GetByNicknameAsync(request.Nickname) != null)
                throw new Exception("Nickname already exists");

            // Şifre hash'leme
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Nickname = request.Nickname,
                PasswordHash = passwordHash,
                FirstName = request.FirstName,
                LastName = request.LastName,
                FavoriteTeam = request.FavoriteTeam,
                CreatedAt = DateTime.UtcNow,
                Level = 1,
                MessageCount = 0,
                IsEmailVerified = false
            };

            await _userRepository.CreateAsync(user);

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
                throw new Exception("Invalid email or password");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid email or password");

            return new AuthResponse
            {
                Token = _jwtService.GenerateToken(user),
                Email = user.Email,
                Nickname = user.Nickname
            };
        }
    }
}
