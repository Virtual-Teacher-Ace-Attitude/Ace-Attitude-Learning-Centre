using System.ComponentModel.DataAnnotations;

using AceAttitude.Data.Models.Contracts;
using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Data.Models
{
    public class Lecture : ILecture
    {
        [Required]
        public int Id { get; set; }

        [Required, MinLength(5, ErrorMessage = ModelErrorMessages.TitleMinLengthErrorMessage),
            MaxLength(50, ErrorMessage = ModelErrorMessages.TitleMaxLengthErrorMessage)]
        public string? Title { get; set; }

       [MaxLength(1000, ErrorMessage = ModelErrorMessages.DescriptionMaxLengthErrorMessage)]
        public string? Description { get; set; }

        public string? VideoFilePath { get; set; }

        public string? TextFilePath { get; set; }


    }
}
