using MatchChat.API.Hubs;
using MatchChat.Infrastructure.Services;
using Microsoft.AspNetCore.SignalR;

namespace MatchChat.API.Services
{
    // MatchChat.API/Services/MatchUpdateService.cs
    public class MatchUpdateService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<MatchHub> _hubContext;
        private readonly ILogger<MatchUpdateService> _logger;

        public MatchUpdateService(
            IServiceProvider serviceProvider,
            IHubContext<MatchHub> hubContext,
            ILogger<MatchUpdateService> logger)
        {
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var footballApiService = scope.ServiceProvider.GetRequiredService<IFootballApiService>();
                        var matches = await footballApiService.GetLiveMatchesAsync();

                        foreach (var match in matches)
                        {
                            await _hubContext.Clients.Group(match.ApiMatchId)
                                .SendAsync("UpdateScore", new
                                {
                                    homeScore = match.HomeScore,
                                    awayScore = match.AwayScore,
                                    minute = match.Minute
                                }, cancellationToken: stoppingToken);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating match scores");
                }

                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
