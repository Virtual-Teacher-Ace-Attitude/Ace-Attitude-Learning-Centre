using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Data.Models.Contracts
{
    public interface ICourse
    {
        public int Id { get; set; }

        public ApplicationUser? CreatedBy { get; set; }

        public string? Title { get; set; }

        public AgeGroup AgeGroup { get; set; }

        public Level Level { get; set; }

        public string? Description { get; set; }

        public DateTime StartingDate { get; set; }

        public bool IsDraft { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
