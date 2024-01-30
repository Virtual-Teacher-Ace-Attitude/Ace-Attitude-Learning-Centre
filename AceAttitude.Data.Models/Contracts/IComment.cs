namespace AceAttitude.Data.Models.Contracts
{
    public interface IComment
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public int? CourseId { get; set; }

        public ICourse? Course { get; set; }

        public string? UserId { get; set; }

        public IApplicationUser? User { get; set; }

        public int Likes { get; set; }

        public ICollection<IApplicationUser> LikedByUsers { get; set; }

        public ICollection<ICommentLike> CommentLikes { get; set; }
    }
}
