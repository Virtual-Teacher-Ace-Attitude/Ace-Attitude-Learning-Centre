using AceAttitude.Data.Models.Contracts.Role;
using AceAttitude.Data.Models.Misc;

using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Data.Models
{
    public class Comment : IsCreatable, IsDeletable, IsModifiable
    {
        public int Id { get; set; }

        [Required, MinLength(1, ErrorMessage = ModelErrorMessages.CommentMinLengthErrorMessage),
            MaxLength(500, ErrorMessage = ModelErrorMessages.CommentMaxLengthErrorMessage)]
        public string Content { get; set; } = null!;

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;

        [Required]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public int Likes { get; set; }

        public ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
