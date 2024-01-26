

using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface IUserService
    {
        IUser GetById(int id);

        IUser CreateUser (IUser user);

        IUser UpdateUser (int id, IUser user);

        IUser DeleteUser (int id);
    }
}
