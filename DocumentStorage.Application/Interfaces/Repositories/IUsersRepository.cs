using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentStorage.Core.Models;

namespace DocumentStorage.Application.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUser(User user);
    }
}
