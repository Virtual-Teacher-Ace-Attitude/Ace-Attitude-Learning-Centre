using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class Teacher : ITeacher
    {
        public string Id { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public ICollection<Course> CreatedCourses { get; set; } = new List<Course>();
    }
}
