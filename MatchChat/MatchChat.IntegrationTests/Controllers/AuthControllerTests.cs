using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MatchChat.Core.Models.Auth;
using MatchChat.Core.Enums;
using Microsoft.Extensions.Hosting;
using MatchChat.API;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using MatchChat.Application.Services;
using MatchChat.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MatchChat.IntegrationTests.Controllers
{
    public class AuthControllerTests
    {
        private readonly HttpClient _client;

        public AuthControllerTests()
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TestStartup>() // TestStartup kullanıyoruz
                             .UseTestServer();
                });

            var host = hostBuilder.Start();
            _client = host.GetTestClient();
        }
    }

    
}