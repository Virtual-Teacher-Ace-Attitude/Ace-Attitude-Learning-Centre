using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Data.Models
{
    public class CommentLike
    {
        [Required]
        public int Id { get; set; }

        public Comment Comment { get; set; } = null!;

        [Required]
        public int CommentId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        [Required]
        public string ApplicationUserId { get; set; } = null!;

        public bool IsLiked { get; set; }
    }
}
