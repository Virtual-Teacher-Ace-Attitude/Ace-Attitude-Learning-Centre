namespace AceAttitude.Data.Models.Contracts
{
    public interface IRating
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public Course? Course { get; set; }

        public ApplicationUser? Student { get; set; }

        public string? StudentId { get; set; }
    }
}
