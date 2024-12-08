using Moq;
using MatchChat.Core.Interfaces;
using MatchChat.Core.Models.Auth;
using MatchChat.Application.Services;
using MatchChat.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MatchChat.API;

namespace MatchChat.IntegrationTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            services.AddControllers();

            // Mock servisleri kaydet
            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(x => x.CreateAsync(It.IsAny<User>())).ReturnsAsync(true);

            var mockJwtService = new Mock<IJwtService>();
            mockJwtService.Setup(x => x.GenerateToken(It.IsAny<User>())).Returns("test-token");

            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(x => x.RegisterAsync(It.IsAny<RegisterRequest>()))
                .ReturnsAsync(new AuthResponse
                {
                    Token = "test-token",
                    Email = "test@test.com",
                    Nickname = "testuser"
                });

            services.AddSingleton<IUserRepository>(mockUserRepo.Object);
            services.AddSingleton<IJwtService>(mockJwtService.Object);
            services.AddSingleton<IAuthService>(mockAuthService.Object);
        }
    }
}
