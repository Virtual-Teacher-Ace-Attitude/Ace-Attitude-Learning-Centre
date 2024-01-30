namespace AceAttitude.Data.Models.Contracts
{
    public interface ITeacher
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Course> CreatedCourses { get; set; }
    }
}
