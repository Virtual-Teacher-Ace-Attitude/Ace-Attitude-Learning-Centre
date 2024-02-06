namespace AceAttitude.Web.DTO.Response
{
    public class RatingResponseDTO
    {
        public decimal Value { get; set; }

        public string Course { get; set; } = null!;

        public DateTime RatedOn { get; set; }
    }
}
