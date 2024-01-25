using Microsoft.AspNetCore.Identity;

namespace AceAttitude.Data.Models.Contracts
{
    public interface IApplicationUser
    {
        public ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
