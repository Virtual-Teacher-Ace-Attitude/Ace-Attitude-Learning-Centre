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
        public IApplicationUser? CreatedBy { get; set; }

        public Level Level { get; set; }

        public AgeGroup AgeGroup { get; set; }

        [MaxLength(1000, ErrorMessage = ModelErrorMessages.DescriptionMaxLengthErrorMessage)]
        public string? Description { get; set; }

        public DateTime StartingDate { get; set; }

        public bool IsDraft { get; set; }

        public ICollection<ILecture> Lectures { get; set; } = new List<ILecture>();

        [Range(1, 5)]
        public double Rating { get; set; }

        public ICollection<IComment> Comments { get; set; } = new List<IComment>();

        // Ratings many-to-many relations
        public ICollection<IApplicationUser> RatedByUsers { get; set; } = new List<IApplicationUser>();

        public ICollection<IRating> Ratings { get; set; } = new List<IRating>();
    }
}
