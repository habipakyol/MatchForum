//using MatchChat.Core.Interfaces;
//using MatchChat.Infrastructure.Data.Repositories;
//using MatchChat.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using MatchChat.Application.Services;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using Microsoft.OpenApi.Models;
//using MatchChat.Infrastructure.Services;
//using MatchChat.API.Hubs;
//using MatchChat.API.Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();

//// Database
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Repositories
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IMatchRepository, MatchRepository>();

//// JWT Authentication
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(
//                Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ClockSkew = TimeSpan.Zero
//        };
//    });

//// Services
//builder.Services.AddScoped<IJwtService, JwtService>();
//builder.Services.AddScoped<IAuthService, AuthService>();

//// Swagger/OpenAPI
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//// HttpClient ve FootballApiService kaydý
//builder.Services.AddHttpClient<IFootballApiService, FootballApiService>();
//app.UseHttpsRedirection();
//// Program.cs içinde builder.Services kýsmýna ekleyin
//builder.Services.AddSignalR();

//// ve app.MapControllers(); satýrýndan sonra ekleyin
//app.MapHub<MatchHub>("/hubs/match");
//// Program.cs içinde diðer service kayýtlarýnýn yanýna ekleyin
//builder.Services.AddHostedService<MatchUpdateService>();
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MatchChat.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}