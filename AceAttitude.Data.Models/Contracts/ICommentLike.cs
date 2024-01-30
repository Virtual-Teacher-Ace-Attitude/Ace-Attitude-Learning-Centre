namespace AceAttitude.Data.Models.Contracts
{
    public interface ICommentLike
    {
        public IComment Comment { get; set; }

        public int? CommentId { get; set; }

        public IApplicationUser User { get; set; }

        public string? UserId { get; set; }
    }
}
