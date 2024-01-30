using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Data.Models.Contracts
{
    public interface ICourse
    {
        public int Id { get; set; }

        public IApplicationUser? CreatedBy { get; set; }

        public string? Title { get; set; }

        public AgeGroup AgeGroup { get; set; }

        public Level Level { get; set; }

        public string? Description { get; set; }

        public DateTime StartingDate { get; set; }

        public bool IsDraft { get; set; }

        public ICollection<ILecture> Lectures { get; set; }

        public ICollection<IComment> Comments { get; set; }
        public ICollection<IApplicationUser> RatedByUsers { get; set; }

        public ICollection<IRating> Ratings { get; set; }
    }
}
