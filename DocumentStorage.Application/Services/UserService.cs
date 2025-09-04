using DocumentStorage.Application.Interfaces;
using DocumentStorage.Application.Interfaces.Repositories;
using DocumentStorage.Core.Models;
namespace DocumentStorage.Application.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;

        public UserService(IPasswordHasher passwordHasher, IUsersRepository usersRepository)
        {
            _passwordHasher = passwordHasher;
            _usersRepository = usersRepository;
        }

        //public async Task<string> Login(string email, string password)
        //{

        //}

        public async Task Register(string email, string password)
        {
            var passwordHashed = _passwordHasher.Generate(password);

            var user = new User(Guid.NewGuid(), email, passwordHashed);

            await _usersRepository.AddUser(user);
        }
    }
}
