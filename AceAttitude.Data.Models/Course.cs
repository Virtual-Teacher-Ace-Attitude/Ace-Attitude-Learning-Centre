using AceAttitude.Data.Models.Misc;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceAttitude.Data.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [Required, MinLength(5, ErrorMessage = ModelErrorMessages.TitleMinLengthErrorMessage),
            MaxLength(50, ErrorMessage = ModelErrorMessages.TitleMaxLengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;

        public Level Level { get; set; }

        public AgeGroup AgeGroup { get; set; }

        [MaxLength(1000, ErrorMessage = ModelErrorMessages.DescriptionMaxLengthErrorMessage)]
        public string Description { get; set; } = null!;

        public DateTime StartingDate { get; set; }

        public bool IsDraft { get; set; }

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

        [Range(1, 5)]
        public double Rating { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public ICollection<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
    }
}
