using Microsoft.AspNetCore.Identity;

namespace AceAttitude.Data.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
