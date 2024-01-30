namespace AceAttitude.Data.Models.Contracts
{
    public interface ITeacher
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public IApplicationUser User { get; set; }

        public ICollection<ICourse> CreatedCourses { get; set; }
    }
}
