using MatchChat.Core.Models.Football;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.Infrastructure.Services
{
    public class FootballApiService : IFootballApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private const int SUPER_LIG_ID = 203; // Türkiye Süper Lig ID'si

        public FootballApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _httpClient.BaseAddress = new Uri("https://v3.football.api-sports.io/");
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _configuration["FootballApi:ApiKey"]);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "v3.football.api-sports.io"); 
        }

        public async Task<IEnumerable<FootballMatch>> GetLiveMatchesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"fixtures?league={SUPER_LIG_ID}&live=all");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                // API response'unu parse edip FootballMatch listesine çevireceğiz
                // API yanıtının yapısına göre bu kısmı düzenleyeceğiz

                return new List<FootballMatch>(); // şimdilik boş liste
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir
                throw new Exception("Error fetching live matches", ex);
            }
        }

        public async Task<IEnumerable<FootballMatch>> GetUpcomingMatchesAsync()
        {
            try
            {
                var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
                var nextWeek = DateTime.UtcNow.AddDays(7).ToString("yyyy-MM-dd");

                var response = await _httpClient.GetAsync(
                    $"fixtures?league={SUPER_LIG_ID}&season=2023&from={today}&to={nextWeek}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                // API response'unu parse edip FootballMatch listesine çevireceğiz

                return new List<FootballMatch>(); // şimdilik boş liste
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching upcoming matches", ex);
            }
        }
    }
}
