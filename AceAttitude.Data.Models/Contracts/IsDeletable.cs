namespace AceAttitude.Data.Models.Contracts
{
    public interface IsDeletable
    {
        public bool IsDeleted => DeletedOn.HasValue;
        public DateTime? DeletedOn { get; set; }
    }
}
