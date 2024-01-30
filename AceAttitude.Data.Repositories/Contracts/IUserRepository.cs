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
        IApplicationUser GetById(int id);

        IApplicationUser CreateUser(IApplicationUser user);

        IApplicationUser UpdateUser(int id, IApplicationUser user);

        IApplicationUser DeleteUser(int id);
    }
}
