namespace AceAttitude.Data.Models.Contracts
{
    public interface IStudent
    {
        public string? Id { get; set; }

        public string? UserId { get; set; }

        public IApplicationUser User { get; set; }

        public ICollection<IRating> Ratings { get; set; }

        public ICollection<ICourse> RatedCourses { get; set; }
    }
}
