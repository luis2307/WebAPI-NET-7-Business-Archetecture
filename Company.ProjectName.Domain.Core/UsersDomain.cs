using Company.ProjectName.Domain.Entity;
using Company.ProjectName.Domain.Interface;
using Company.ProjectName.Infrastructure.Interface;

namespace Company.ProjectName.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;
        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Users Authenticate(string userName) => _usersRepository.Authenticate(userName);

        public bool Exist(string username) => _usersRepository.Exist(username) > 0;

        public async Task<bool> ExistAsync(string username) => await _usersRepository.ExistAsync(username) > 0;

        public bool Register(Users users) => _usersRepository.Insert(users);

    }
}
