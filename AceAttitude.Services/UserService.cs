using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
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
        public ApplicationUser CreateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser UpdateUser(int id, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
