using AceAttitude.Data.Models;

namespace AceAttitude.Services.Contracts
{
    public interface ICommentService
    {
        List<Comment> GetComments(Course course);
        Comment CreateComment(Comment comment, Course course, ApplicationUser user);

        Comment UpdateComment(int commentId, int courseId, string content, ApplicationUser user);

        Comment DeleteComment(int commentId, int courseId, ApplicationUser user);

        Comment LikeComment(int commentId, int courseId, ApplicationUser user);
    }
}
