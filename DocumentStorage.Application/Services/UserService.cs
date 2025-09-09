using DocumentStorage.Application.Interfaces;
using DocumentStorage.Application.Interfaces.Repositories;
using DocumentStorage.Core.Models;
namespace DocumentStorage.Application.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IPasswordHasher passwordHasher, IUsersRepository usersRepository, IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _usersRepository = usersRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);

            if (user != null)
            {
                var result = _passwordHasher.Verify(password, user.PasswordHash);
                if (result)
                {
                    var token = _jwtProvider.GenerateToken(user);
                    return token;
                }
                throw new Exception("Incorrect password");
            }
            throw new Exception("No such user");
        }

        public async Task Register(string email, string password)
        {
            var passwordHashed = _passwordHasher.Generate(password);

            var user = new User(Guid.NewGuid(), email, passwordHashed);

            await _usersRepository.AddUser(user);
        }
    }
}
