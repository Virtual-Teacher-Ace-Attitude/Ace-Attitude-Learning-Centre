

using AceAttitude.Data.Models.Contracts;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;

namespace AceAttitude.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }
        public IUser CreateUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public IUser DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IUser UpdateUser(int id, IUser user)
        {
            throw new NotImplementedException();
        }
    }
}
