using AceAttitude.Data.Models;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        ApplicationUser GetById(int id);

        ApplicationUser CreateUser(ApplicationUser user);

        ApplicationUser UpdateUser(int id, ApplicationUser user);

        ApplicationUser DeleteUser(int id);
    }
}
