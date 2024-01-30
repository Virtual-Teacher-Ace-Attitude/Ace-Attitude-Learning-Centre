using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class Student : IStudent
    {
        public string? Id { get; set; }

        public string? UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
