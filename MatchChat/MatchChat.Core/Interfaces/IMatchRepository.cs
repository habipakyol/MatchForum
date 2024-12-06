using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchChat.Core.Entities;

namespace MatchChat.Core.Interfaces
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetActiveMatchesAsync();
        Task<IEnumerable<Match>> GetUpcomingMatchesAsync();
        Task<Match> GetByIdAsync(Guid id);
        Task<bool> UpdateScoreAsync(Guid id, int homeScore, int awayScore, int minute);
    }
}