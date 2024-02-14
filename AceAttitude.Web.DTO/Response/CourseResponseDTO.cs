using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Web.DTO.Response
{
    public class CourseResponseDTO
    {
        public string Title { get; set; } = null!;

        public string Level { get; set; } = null!;

        public string AgeGroup { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public DateTime StartingDate { get; set; }

        public bool IsDraft { get; set; }

        public bool IsCompleted { get; set; }

        public string Rating { get; set; } = null!;
    }
}
