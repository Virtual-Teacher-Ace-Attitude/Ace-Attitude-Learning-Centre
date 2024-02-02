using AceAttitude.Data.Models;
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
            //Must be logged in.
            return commentRepository.CreateComment(comment, course);
        }

        public Comment DeleteComment(int id, ApplicationUser user)
        {
            //Must be comment creator.
            return commentRepository.DeleteComment(id);
        }

        public Comment GetById(int id)
        {
            return commentRepository.GetById(id);
        }

        public Comment LikeComment(int id, ApplicationUser user)
        {
            //Must be logged in.
            return LikeComment(id, user);
        }

        public Comment UpdateComment(int id, string content, ApplicationUser user)
        {
            //Must be comment creator.
            return commentRepository.UpdateComment(id, content);
        }
    }
}
