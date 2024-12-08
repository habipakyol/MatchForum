using MatchChat.Application.Services;
using MatchChat.Core.Entities;
using MatchChat.Core.Enums;
using MatchChat.Core.Interfaces;
using MatchChat.Core.Models.Auth;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.UnitTests.Services
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task Register_WithValidData_ShouldCreateUser()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepository>();
            var mockJwtService = new Mock<IJwtService>();

            // Setup mock repository to return success
            mockUserRepo.Setup(x => x.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(true); // CreateAsync başarılı olacak şekilde ayarlıyoruz

            // Setup JWT service to return a token
            mockJwtService.Setup(x => x.GenerateToken(It.IsAny<User>()))
                .Returns("test-token");

            var authService = new AuthService(mockUserRepo.Object, mockJwtService.Object);

            var request = new RegisterRequest
            {
                Email = "test@test.com",
                Password = "Test123!",
                Nickname = "testuser",
                FirstName = "Test",
                LastName = "User",
                FavoriteTeam = TurkishTeam.Galatasaray
            };

            // Act
            var result = await authService.RegisterAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Token);
            mockUserRepo.Verify(x => x.CreateAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
