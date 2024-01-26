using AceAttitude.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        IUser GetById(int id);

        IUser CreateUser(IUser user);

        IUser UpdateUser(int id, IUser user);

        IUser DeleteUser(int id);
    }
}
