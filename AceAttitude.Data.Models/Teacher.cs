using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class Teacher : ITeacher
    {
        public string Id { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public IApplicationUser User { get; set; } = null!;

        public ICollection<ICourse> CreatedCourses { get; set; } = new List<ICourse>();
    }
}
