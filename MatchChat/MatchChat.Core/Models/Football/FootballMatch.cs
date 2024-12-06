using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.Core.Models.Football
{
    public class FootballMatch
    {
        public string ApiMatchId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public string Status { get; set; }
        public int? Minute { get; set; }
        public DateTime StartTime { get; set; }
    }
}
