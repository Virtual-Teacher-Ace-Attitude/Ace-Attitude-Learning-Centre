using AceAttitude.Data.Models.Contracts.Role;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceAttitude.Data.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.Id = new Guid().ToString();
        }

        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }

        public ICollection<Course> CreatedCourses { get; set; } = new List<Course>();
    }
}
