namespace AceAttitude.Data.Models.Contracts.Role
{
    public interface IsModifiable
    {
        public bool IsModified { get; }
        public DateTime? ModifiedOn { get; set; }
    }
}
