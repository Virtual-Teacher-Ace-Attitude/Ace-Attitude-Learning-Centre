using AceAttitude.Data.Models.Contracts.Role;
using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Data.Models
{
    public class StudentCourses : IsCreatable
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string StudentId { get; set; } = null!;

        public Student Student { get; set; } = null!;

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;

        public bool IsCompleted { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
