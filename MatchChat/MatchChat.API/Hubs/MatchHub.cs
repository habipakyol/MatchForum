// MatchChat.API/Hubs/MatchHub.cs
using Microsoft.AspNetCore.SignalR;
using MatchChat.Core.Models.Chat;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MatchChat.API.Hubs
{
    [Authorize]
    public class MatchHub : Hub
    {
        private static Dictionary<string, DateTime> _userLastMessageTime = new();
        private const int MESSAGE_COOLDOWN_SECONDS = 5;

        public async Task JoinMatch(string matchId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, matchId);
            await Clients.Group(matchId).SendAsync("UserJoined", Context.User.FindFirst("nickname")?.Value);
        }

        public async Task LeaveMatch(string matchId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, matchId);
            await Clients.Group(matchId).SendAsync("UserLeft", Context.User.FindFirst("nickname")?.Value);
        }

        public async Task SendMessage(string matchId, string message, string? quotedMessageId = null)
        {
            var userId = Context.User.FindFirst(ClaimTypes.Name)?.Value;
            var nickname = Context.User.FindFirst("nickname")?.Value;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(nickname))
            {
                throw new HubException("Unauthorized");
            }

            // Spam kontrolü
            if (_userLastMessageTime.TryGetValue(userId, out DateTime lastMessageTime))
            {
                var timeSinceLastMessage = (DateTime.UtcNow - lastMessageTime).TotalSeconds;
                if (timeSinceLastMessage < MESSAGE_COOLDOWN_SECONDS)
                {
                    throw new HubException($"Please wait {MESSAGE_COOLDOWN_SECONDS - (int)timeSinceLastMessage} seconds before sending another message.");
                }
            }

            var chatMessage = new ChatMessage
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Nickname = nickname,
                Message = message,
                QuotedMessageId = quotedMessageId,
                Timestamp = DateTime.UtcNow
            };

            _userLastMessageTime[userId] = DateTime.UtcNow;

            await Clients.Group(matchId).SendAsync("ReceiveMessage", chatMessage);
        }
    }
}