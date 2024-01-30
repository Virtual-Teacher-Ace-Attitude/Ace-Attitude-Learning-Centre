namespace AceAttitude.Data.Models.Contracts
{
    public interface IStudent
    {
        public string? Id { get; set; }

        public string? UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
