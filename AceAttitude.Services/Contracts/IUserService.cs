

using AceAttitude.Data.Models;

namespace AceAttitude.Services.Contracts
{
    public interface IUserService
    {
        ApplicationUser GetById(int id);

        ApplicationUser CreateUser(ApplicationUser user);

        ApplicationUser UpdateUser(int id, ApplicationUser user);

        ApplicationUser DeleteUser(int id);

        public void CheckEmailExists(string email);

        public ApplicationUser GetByEmail(string email);
    }
}
