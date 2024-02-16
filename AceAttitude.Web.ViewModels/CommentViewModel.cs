using AceAttitude.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Web.ViewModels
{
    public class CommentViewModel
    {

        private const string CommentMinLengthErrorMessage = "Comment cannot be empty";
        private const string CommentMaxLengthErrorMessage = "Comment cannot be more than 500 characters long";

        [Required, MinLength(ValidationConstants.CommentMinLength, ErrorMessage = CommentMinLengthErrorMessage),
            MaxLength(ValidationConstants.CommentMaxLength, ErrorMessage = CommentMaxLengthErrorMessage)]
        public string Content { get; set; } = null!;
    }

}
