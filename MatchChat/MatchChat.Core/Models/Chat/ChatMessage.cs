using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.Core.Models.Chat
{
    public class ChatMessage
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Nickname { get; set; }
        public string Message { get; set; }
        public string? QuotedMessageId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
