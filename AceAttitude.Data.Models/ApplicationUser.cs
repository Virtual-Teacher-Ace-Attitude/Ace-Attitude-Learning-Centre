using AceAttitude.Data.Models.Contracts.Role;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceAttitude.Data.Models
{
    public class ApplicationUser : IdentityUser, IsCreatable, IsModifiable, IsDeletable
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey("Teacher")]
        public string? TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        [ForeignKey("Student")]
        public string? StudentId { get; set; }

        public Student? Student { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [NotMapped]
        public bool IsModified => ModifiedOn.HasValue;

        public DateTime? DeletedOn { get; set; }

        [NotMapped]
        public bool IsDeleted => DeletedOn.HasValue;

        public string? PictureFilePath { get; set; }

        public string? NoteFilePath { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = new HashSet<IdentityUserRole<string>>();

        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = new HashSet<IdentityUserClaim<string>>();

        //public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = new HashSet<IdentityUserLogin<string>>();
    }
}
