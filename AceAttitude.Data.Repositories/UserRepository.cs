using AceAttitude.Data.Models.Contracts;
using AceAttitude.Data.Repositories.Contracts;


namespace AceAttitude.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
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
