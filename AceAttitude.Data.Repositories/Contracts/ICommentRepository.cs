
using AceAttitude.Data.Models;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ICommentRepository
    {
        List<Comment> GetComments(Course course);
        Comment CreateComment (Comment comment, Course course);

        Comment GetById (int commentId, int courseId);

        Comment UpdateComment (int commentId, int courseId, string content);

        Comment DeleteComment (int commentId, int courseId);

        Comment LikeComment (int commentId, int courseId, ApplicationUser user);


    }
}
