

using AceAttitude.Data.Models;

namespace AceAttitude.Services.Contracts
{
    public interface IUserService
    {
        ApplicationUser GetById(string id);

        ApplicationUser Create(ApplicationUser user);

        ApplicationUser CreateTeacher(ApplicationUser user);

        ApplicationUser CreateStudent(ApplicationUser user);

        ApplicationUser Update(string id, ApplicationUser user);

        ApplicationUser Delete(string id);

        public void CheckEmailExists(string email);

        public ApplicationUser GetByEmail(string email);
    }
}
