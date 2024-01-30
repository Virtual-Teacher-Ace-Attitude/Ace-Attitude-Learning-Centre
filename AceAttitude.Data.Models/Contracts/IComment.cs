namespace AceAttitude.Data.Models.Contracts
{
    public interface IComment
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public int? CourseId { get; set; }

        public Course? Course { get; set; }

        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public int Likes { get; set; }

        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}
