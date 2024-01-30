namespace AceAttitude.Data.Models.Contracts
{
    public interface IRating
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public ICourse? Course { get; set; }

        public IApplicationUser? Student { get; set; }

        public string? StudentId { get; set; }
    }
}
