using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;

namespace AceAttitude.Services
{
    public class CommentService : ICommentService
    {
        private const string UnableToModifyCommentErrorMessage = "You must be the comment creator or an admin in order to modify or delete this comment.";

        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public Comment CreateComment(Comment comment, Course course, ApplicationUser user)
        {
            return commentRepository.CreateComment(comment, course);
        }

        public Comment DeleteComment(int commentId, int courseId, ApplicationUser user)
        {
            EnsureUserIsCreatorOrAdmin(user, commentId, courseId);

            return commentRepository.DeleteComment(commentId, courseId);
        }

        public Comment GetComment(int commentId, int courseId)
        {
            return commentRepository.GetById(commentId, courseId);
        }

        public List<Comment> GetComments(Course course)
        {
            return commentRepository.GetComments(course);
        }

        public Comment LikeComment(int commentId, int courseId, ApplicationUser user)
        {
            return commentRepository.LikeComment(commentId, courseId, user);
        }

        public Comment UpdateComment(int commentId, int courseId, string content, ApplicationUser user)
        {
            EnsureUserIsCreatorOrAdmin(user, commentId, courseId);

            return commentRepository.UpdateComment(commentId, courseId, content);
        }

        private Comment EnsureUserIsCreatorOrAdmin(ApplicationUser user, int commentId, int courseId)
        {
            Comment comment = commentRepository.GetById(commentId, courseId);
            if (user.UserType != UserType.Admin && comment.User != user)
            {
                throw new UnauthorizedOperationException
                    (UnableToModifyCommentErrorMessage);
            }
            return comment;
        }
    }
}
