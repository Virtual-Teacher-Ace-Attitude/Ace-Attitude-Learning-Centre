using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

using AceAttitude.Data.Models.Contracts.Role;
using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser, IsCreatable, IsModifiable, IsDeletable
    {
        public ApplicationUser()
        {
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set ; }

        [NotMapped]
        public bool IsModified => ModifiedOn.HasValue;

        public DateTime? DeletedOn { get; set; }

        [NotMapped]
        public bool IsDeleted => DeletedOn.HasValue;

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

    }
}
