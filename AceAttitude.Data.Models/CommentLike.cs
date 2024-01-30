namespace AceAttitude.Data.Models
{
    public class CommentLike
    {
        public Comment Comment { get; set; } = null!;

        public int? CommentId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public string? UserId { get; set; }

        public bool IsLiked { get; set; }
    }
}
