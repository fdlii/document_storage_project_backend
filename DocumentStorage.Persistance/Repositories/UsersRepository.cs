using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentStorage.Persistance.Entities;
using DocumentStorage.Application.Interfaces.Repositories;
using DocumentStorage.Core.Models;
using System.Runtime.InteropServices;

namespace DocumentStorage.Persistance.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsersRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task AddUser(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            };

            await _appDbContext.Users.AddAsync(userEntity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            //return await _appDbContext.Users
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(user => user.Email == email);
            return new User(Guid.NewGuid(), "email", "password");
        }

        
    }
}
