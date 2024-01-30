using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class Student : IStudent
    {
        public string? Id { get; set; }

        public string? UserId { get; set; }

        public IApplicationUser User { get; set; } = null!;

        public ICollection<IRating> Ratings { get; set; } = new List<IRating>();

        public ICollection<ICourse> RatedCourses { get; set; } = new List<ICourse>();
    }
}
