namespace AceAttitude.Data.Models.Contracts.Role
{
    public interface IsModifiable
    {
        public DateTime? ModifiedOn { get; set; }
    }
}
