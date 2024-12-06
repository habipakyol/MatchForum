using MatchChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
