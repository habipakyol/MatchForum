using MatchChat.Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.UnitTests.Services
{
    public class FootballApiServiceTests
    {
        [Fact]
        public async Task GetLiveMatches_ShouldReturnMatches()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var service = new FootballApiService(mockHttpClient.Object);

            // Act
            var matches = await service.GetLiveMatchesAsync();

            // Assert
            Assert.NotNull(matches);
        }
    }
}
