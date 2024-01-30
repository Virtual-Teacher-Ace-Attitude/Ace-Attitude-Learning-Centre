using System.ComponentModel.DataAnnotations;

using AceAttitude.Data.Models.Contracts;
using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Data.Models
{
    public class Comment : IComment
    {
        public int Id { get; set; }

        [Required, MinLength(1, ErrorMessage = ModelErrorMessages.CommentMinLengthErrorMessage),
            MaxLength(500, ErrorMessage = ModelErrorMessages.CommentMaxLengthErrorMessage)]
        public string? Content { get; set; }

        [Required]
        public int? CourseId { get; set; }

        public Course? Course { get; set; }

        [Required]
        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public int Likes { get; set; }

        public ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();
    }
}
