
using MatchChat.Core.Enums;

namespace MatchChat.Core.Entities
{
    // MatchChat.Core/Entities/User.cs
    public class User
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public TurkishTeam FavoriteTeam { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEmailVerified { get; set; }
        public int Level { get; set; }
        public int MessageCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
    }
}
