using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithDB.Models;

namespace WorkingWithDB.Repositories
{
    public interface IUsersRepository
    {
        Task<UserEntity> GetUserByEmailAsync(string email);
    }
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsersRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _appDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
