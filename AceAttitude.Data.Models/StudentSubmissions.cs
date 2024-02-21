namespace AceAttitude.Data.Models
{
    public class StudentSubmissions
    {
        public int Id { get; set; }

        public Student Student { get; set; } = null!;

        public string StudentId { get; set; } = null!;

        public Lecture Lecture { get; set; } = null!;

        public string LectureId { get; set; } = null!;

        public string TextFilePath { get; set; } = null!;
    }
}
