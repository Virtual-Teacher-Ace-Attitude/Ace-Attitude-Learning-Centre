using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class CommentLike
    {
        public IComment Comment { get; set; } = null!;

        public int? CommentId { get; set; }

        public IApplicationUser User { get; set; } = null!;

        public string? UserId { get; set; }

        public bool IsLiked { get; set; }
    }
}
