using System.ComponentModel.DataAnnotations;

using AceAttitude.Data.Models.Contracts;
using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Data.Models
{
    public class Course : ICourse
    {
        [Required]
        public int Id { get; set; }

        [Required, MinLength(5, ErrorMessage = ModelErrorMessages.TitleMinLengthErrorMessage),
            MaxLength(50, ErrorMessage = ModelErrorMessages.TitleMaxLengthErrorMessage)]
        public string? Title { get; set; }

        public int TeacherId { get; set; }
        public ApplicationUser? CreatedBy { get; set; }

        public Level Level { get; set; }

        public AgeGroup AgeGroup { get; set; }

        [MaxLength(1000, ErrorMessage = ModelErrorMessages.DescriptionMaxLengthErrorMessage)]
        public string? Description { get; set; }

        public DateTime StartingDate { get; set; }

        public bool IsDraft { get; set; }

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

        [Range(1, 5)]
        public double Rating { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
