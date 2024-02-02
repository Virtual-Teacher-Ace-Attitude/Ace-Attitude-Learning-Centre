using AceAttitude.Data.Models.Contracts.Role;
using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Data.Models
{
    public class Rating : IsCreatable
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Value { get; set; }

        public bool IsRated { get; set; }
        public Course Course { get; set; } = null!;

        [Required]
        public int CourseId { get; set; }

        public Student Student { get; set; } = null!;

        [Required]
        public string StudentId { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
