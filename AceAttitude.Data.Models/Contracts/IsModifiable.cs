namespace AceAttitude.Data.Models.Contracts
{
    public interface IsModifiable
    {
        public bool IsModified => ModifiedOn.HasValue;
        public DateTime? ModifiedOn { get; set; }
    }
}
