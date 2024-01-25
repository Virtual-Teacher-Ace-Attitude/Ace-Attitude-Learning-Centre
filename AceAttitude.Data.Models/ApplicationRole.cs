using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

using AceAttitude.Data.Models.Contracts.Role;

namespace AceAttitude.Data.Models
{
    public class ApplicationRole : IdentityRole, IsCreatable, IsModifiable, IsDeletable
    {
        public DateTime? DeletedOn { get; set; }

        [NotMapped]
        public bool IsDeleted => DeletedOn.HasValue;

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [NotMapped]
        public bool IsModified => ModifiedOn.HasValue;
    }
}
