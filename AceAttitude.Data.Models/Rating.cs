using System.ComponentModel.DataAnnotations;

using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class Rating
    {
        [Required]
        public int Id { get; set; }

        public int CourseId { get; set; }

        public ICourse? Course { get; set; } = null!;

        public IApplicationUser? Student { get; set; } = null!;

        public string? StudentId { get; set; }
    }
}
