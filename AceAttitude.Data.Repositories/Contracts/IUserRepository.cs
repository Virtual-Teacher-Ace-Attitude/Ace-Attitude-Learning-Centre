using AceAttitude.Data.Models;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        ApplicationUser GetById(int id);

        ApplicationUser GetByEmail(string email);

        ApplicationUser Create(ApplicationUser user);

        ApplicationUser Update(int id, ApplicationUser user);

        ApplicationUser Delete(int id);

        public bool CheckEmailExists(string email);
    }
}
