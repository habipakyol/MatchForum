using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchChat.Core.Entities;
using MatchChat.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatchChat.Infrastructure.Data.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetActiveMatchesAsync()
        {
            return await _context.Matches
                .Where(m => m.IsActive)
                .OrderBy(m => m.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Match>> GetUpcomingMatchesAsync()
        {
            var today = DateTime.Today;
            return await _context.Matches
                .Where(m => !m.IsActive && m.StartTime.Date >= today)
                .OrderBy(m => m.StartTime)
                .ToListAsync();
        }

        public async Task<Match> GetByIdAsync(Guid id)
        {
            return await _context.Matches.FindAsync(id);
        }

        public async Task<bool> UpdateScoreAsync(Guid id, int homeScore, int awayScore, int minute)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return false;

            match.HomeScore = homeScore;
            match.AwayScore = awayScore;
            match.CurrentMinute = minute;
            match.LastUpdated = DateTime.UtcNow;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}