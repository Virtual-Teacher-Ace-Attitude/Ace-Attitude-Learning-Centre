using System.ComponentModel.DataAnnotations;

using AceAttitude.Data.Models.Contracts;
using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Data.Models
{
    internal class Comment : IComment
    {
        public int Id { get; set; }

        [Required, MinLength(1, ErrorMessage = ModelErrorMessages.CommentMinLengthErrorMessage),
            MaxLength(500, ErrorMessage = ModelErrorMessages.CommentMaxLengthErrorMessage)]
        public string? Content { get; set; }

        [Required]
        public int? CourseId { get; set; }

        public ICourse? Course { get; set; }

        [Required]
        public string? UserId { get; set; }

        public IApplicationUser? User { get; set; }

        public int Likes { get; set; }

        public ICollection<ICommentLike> CommentLikes { get; set; } = new List<ICommentLike>();
    }
}
