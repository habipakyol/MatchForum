using MatchChat.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.Core.Extensions
{
    // MatchChat.Core/Extensions/TurkishTeamExtensions.cs
    public static class TurkishTeamExtensions
    {
        public static string ToDisplayName(this TurkishTeam team)
        {
            return team.ToString().Replace("_", " ");
        }
    }
}
