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
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [NotMapped]
        public bool IsModified => ModifiedOn.HasValue;

        public DateTime? DeletedOn { get; set; }

        [NotMapped]
        public bool IsDeleted => DeletedOn.HasValue;

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public bool IsTeacher { get; set; }

        public bool IsAdmin { get; set; }

        public string? PictureFilePath { get; set; }

        public string? NoteFilePath { get; set; }

        public ICollection<IComment> Comments { get; set; } = new List<IComment>();

        // Comments many-to-many relations
        public ICollection<ICommentLike> CommentLikes { get; set; } = new List<ICommentLike>();

        public ICollection<IComment> LikedComments { get; set; } = new List<IComment>();

        // Student-Only
        // Ratings many-to-many relations
        //public string LectureNote { get; set; }

        public ICollection<IRating> Ratings { get; set; } = new List<IRating>();

        public ICollection<ICourse> RatedCourses { get; set; } = new List<ICourse>();

        // Teacher-Only
        public ICollection<ICourse> CreatedCourses { get; set; } = new List<ICourse>();
    }
}
