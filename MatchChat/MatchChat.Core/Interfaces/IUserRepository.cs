using MatchChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchChat.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByNicknameAsync(string nickname);
        Task<bool> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
    }
}
