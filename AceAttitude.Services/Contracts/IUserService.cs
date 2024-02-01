

using AceAttitude.Data.Models;

namespace AceAttitude.Services.Contracts
{
    public interface IUserService
    {
        ApplicationUser GetById(int id);

        ApplicationUser Create(ApplicationUser user);

        ApplicationUser Update(int id, ApplicationUser user);

        ApplicationUser Delete(int id);

        public void CheckEmailExists(string email);

        public ApplicationUser GetByEmail(string email);
    }
}
