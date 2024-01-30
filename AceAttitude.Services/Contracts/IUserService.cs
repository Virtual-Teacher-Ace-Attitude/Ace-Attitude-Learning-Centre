

using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface IUserService
    {
        IApplicationUser GetById(int id);

        IApplicationUser CreateUser (IApplicationUser user);

        IApplicationUser UpdateUser (int id, IApplicationUser user);

        IApplicationUser DeleteUser (int id);
    }
}
