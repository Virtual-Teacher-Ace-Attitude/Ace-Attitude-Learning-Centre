using Microsoft.AspNetCore.Identity;

namespace AceAttitude.Data.Models.Contracts
{
    public interface IApplicationUser
    {
        public ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public bool IsTeacher { get; set; }

        public bool IsAdmin { get; set; }

        public string? PictureFilePath { get; set; }

        public string? NoteFilePath { get; set; }

        public ICollection<ICourse> CreatedCourses { get; set; }

        public ICollection<IComment> Comments { get; set; }

        public ICollection<ICommentLike> CommentLikes { get; set; }

        public ICollection<IComment> LikedComments { get; set; }

        public ICollection<IRating> Ratings { get; set; }

        public ICollection<ICourse> RatedCourses { get; set; }
    }
}
