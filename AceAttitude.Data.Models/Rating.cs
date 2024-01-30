using System.ComponentModel.DataAnnotations;

using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class Rating : IRating
    {
        [Required]
        public int Id { get; set; }

        public int CourseId { get; set; }

        public Course? Course { get; set; } = null!;

        public ApplicationUser? Student { get; set; } = null!;

        public string? StudentId { get; set; }
    }
}
