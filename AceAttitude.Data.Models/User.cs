
using System.ComponentModel.DataAnnotations;
using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class User : IUser
    {

        [Required]
        public int Id { get; set; }

        [Required, MinLength(2, ErrorMessage = ModelErrorMessages.NameMinLengthErrorMessage),
                    MaxLength(20, ErrorMessage = ModelErrorMessages.NameMaxLengthErrorMessage)]
        public string FirstName { get; set; }

        [Required, MinLength(2, ErrorMessage = ModelErrorMessages.NameMinLengthErrorMessage),
            MaxLength(20, ErrorMessage = ModelErrorMessages.NameMaxLengthErrorMessage)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsTeacher { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted => DeletedOn.HasValue;

        public DateTime? DeletedOn { get; set; }

        public bool IsModified => ModifiedOn.HasValue;

        public DateTime? ModifiedOn { get; set; }
    }
}
