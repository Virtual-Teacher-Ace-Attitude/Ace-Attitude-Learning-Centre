namespace AceAttitude.Data.Models.Contracts.Role
{
    public interface IsDeletable
    {
        public bool IsDeleted { get; }
        public DateTime? DeletedOn { get; set; }
    }
}
