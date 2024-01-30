namespace AceAttitude.Data.Models.Contracts
{
    public interface IApplicationUser
    {
        //public ICollection<IdentityUserRole<string>> Roles { get; set; }

        //public ICollection<IdentityUserClaim<string>> Claims { get; set; }

        //public ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public string? TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public string? StudentId { get; set; }

        public Student? Student { get; set; }

        public string? PictureFilePath { get; set; }

        public string? NoteFilePath { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}
