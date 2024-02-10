using AceAttitude.Common.Constants;
using AceAttitude.Data.Models.Misc;

using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Web.ViewModels
{
    public class RegisterViewModel
    {
        private const string InvalidPasswordLengthErrorMessage =
            "The password must be at least 8 symbols long!";
        private const string InvalidPasswordTypeErrorMessage =
            "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special symbol!";

        private const string InvalidFirstNameLengthErrorMessage =
            "First name must be between 2 and 20 symbols long!";
        private const string InvalidLastNameLengthErrorMessage =
            "Last name must be between 2 and 20 symbols long!";

        private const string InvalidEmailErrorMessage = "Invalid email address!";

        private const string PasswordsNotMatchingErrorMessage = "The password and confirmation password do not match!";

        [Required]
        [EmailAddress(ErrorMessage = InvalidEmailErrorMessage)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.PasswordMinLength, ErrorMessage = InvalidPasswordLengthErrorMessage)]
        [RegularExpression(ValidationConstants.PasswordRegex, ErrorMessage = InvalidPasswordTypeErrorMessage)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password), ErrorMessage = PasswordsNotMatchingErrorMessage)]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: ValidationConstants.NameMaxLength,
            MinimumLength = ValidationConstants.NameMinLength,
            ErrorMessage = InvalidFirstNameLengthErrorMessage)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: ValidationConstants.NameMaxLength,
            MinimumLength = ValidationConstants.NameMinLength,
            ErrorMessage = InvalidLastNameLengthErrorMessage)]
        public string LastName { get; set; } = null!;

        [Required]
        public UserType UserType { get; set; }
    }
}
