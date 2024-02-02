using AceAttitude.Data.Models;

namespace AceAttitude.Services.Contracts
{
    public interface ICommentService
    {
        Comment CreateComment(Comment comment, Course course, ApplicationUser user);

        Comment GetById(int id);

        Comment UpdateComment(int id, string content, ApplicationUser user);

        Comment DeleteComment(int id, ApplicationUser user);

        Comment LikeComment(int id, ApplicationUser user);
    }
}
