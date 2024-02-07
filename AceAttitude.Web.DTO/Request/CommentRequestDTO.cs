using AceAttitude.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Web.DTO.Request
{
    public class CommentRequestDTO
    {
        private const string CommentMinLengthErrorMessage = "Comment cannot be empty";
        private const string CommentMaxLengthErrorMessage = "Comment cannot be more than 500 characters long";

        [Required, MinLength(ValidationConstants.CommentMinLength, ErrorMessage = CommentMinLengthErrorMessage),
            MaxLength(ValidationConstants.CommentMaxLength, ErrorMessage = CommentMaxLengthErrorMessage)]
        public string Content { get; set; } = null!;
    }
}
