

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
        public IApplicationUser CreateUser(IApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public IApplicationUser DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IApplicationUser UpdateUser(int id, IApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
