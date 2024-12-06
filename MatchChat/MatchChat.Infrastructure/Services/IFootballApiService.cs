using MatchChat.Core.Models.Football;

namespace MatchChat.Infrastructure.Services
{
    public interface IFootballApiService
    {
        Task<IEnumerable<FootballMatch>> GetLiveMatchesAsync();
        Task<IEnumerable<FootballMatch>> GetUpcomingMatchesAsync();
    }
}