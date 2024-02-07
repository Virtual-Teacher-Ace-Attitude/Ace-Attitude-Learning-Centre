using AceAttitude.Data.Models.Misc;
using AceAttitude.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Web.DTO.Response
{
    public class CommentResponseDTO
    {
        public string Content { get; set; } = null!;

        public string User { get; set; } = null!;

        public int Likes { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
