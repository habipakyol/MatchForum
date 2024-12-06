using MatchChat.Core.Models.Auth;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.IntegrationTests.Controllers
{
    // MatchChat.IntegrationTests/Controllers/AuthControllerTests.cs
    public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public AuthControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Register_WithValidData_ShouldReturnToken()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new RegisterRequest
            {
                Email = "test@test.com",
                Password = "Test123!",
                Nickname = "testuser"
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/auth/register", request);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
            Assert.NotNull(result?.Token);
        }
    }
}
