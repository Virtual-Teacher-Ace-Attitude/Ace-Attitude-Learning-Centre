namespace AceAttitude.Data.Models.Contracts
{
    public interface ILecture
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? VideoFilePath { get; set; }

        public string? TextFilePath { get; set; }
    }
}
