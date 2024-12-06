using System;

namespace MatchChat.Core.Entities
{
    public class Match
    {
        public Guid Id { get; set; }
        public string ApiMatchId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsActive { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int? CurrentMinute { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}