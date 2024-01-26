using AceAttitude.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Data.Models
{
    public class Course : ICourse
    {
        [Required, MinLength(5, ErrorMessage = ModelErrorMessages.TitleMinLengthErrorMessage),
            MaxLength(50, ErrorMessage = ModelErrorMessages.TitleMaxLengthErrorMessage)]
        public string Title { get; set; }
        public Level Level { get; set; }

        public AgeGroup AgeGroup { get; set; }

        [MaxLength(1000, ErrorMessage = ModelErrorMessages.DescriptionMaxLengthErrorMessage)]
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public List<ILecture> Lectures { get; set; }
    }
}
