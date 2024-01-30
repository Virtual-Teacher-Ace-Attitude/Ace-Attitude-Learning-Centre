namespace AceAttitude.Data.Models.Contracts
{
    public interface ICommentLike
    {
        public Comment Comment { get; set; }

        public int? CommentId { get; set; }

        public ApplicationUser User { get; set; }

        public string? UserId { get; set; }

        public bool IsLiked { get; set; }
    }
}
