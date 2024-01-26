

using AceAttitude.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Data.Models
{

    public class Lecture : ILecture
    {

        [Required, MinLength(5, ErrorMessage = ModelErrorMessages.TitleMinLengthErrorMessage),
            MaxLength(50, ErrorMessage = ModelErrorMessages.TitleMaxLengthErrorMessage)]
        public string Title { get; set; }

       [MaxLength(1000, ErrorMessage = ModelErrorMessages.DescriptionMaxLengthErrorMessage)]
        public string Description { get; set; }

        //Lectures must have a video. Video from front end?

        //Lectures must have a text document assignment. Assignment from front end?
    }
}
