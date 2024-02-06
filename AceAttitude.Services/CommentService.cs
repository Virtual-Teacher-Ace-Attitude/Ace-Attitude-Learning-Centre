using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;

namespace AceAttitude.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public Comment CreateComment(Comment comment, Course course, ApplicationUser user)
        {
            return commentRepository.CreateComment(comment, course);
        }

        public Comment DeleteComment(int id, ApplicationUser user)
        {
            EnsureUserIsCreatorOrAdmin(user, id);
            return commentRepository.DeleteComment(id);
        }

        public List<Comment> GetComments(Course course)
        {
            return commentRepository.GetComments(course);
        }

        public Comment GetById(int id)
        {
            return commentRepository.GetById(id);
        }

        public Comment LikeComment(int id, ApplicationUser user)
        {
            return LikeComment(id, user);
        }

        public Comment UpdateComment(int id, string content, ApplicationUser user)
        {
            EnsureUserIsCreatorOrAdmin(user, id);
            return commentRepository.UpdateComment(id, content);
        }

        private void EnsureUserIsCreatorOrAdmin(ApplicationUser user, int commentId)
        {
            Comment comment = commentRepository.GetById(commentId);
            if (user.UserType != UserType.Admin && comment.User != user)
            {
                throw new UnauthorizedOperationException
                    ("You must be the comment creator or an admin in order to modify or delete this comment.");
            }
        }
    }
}
