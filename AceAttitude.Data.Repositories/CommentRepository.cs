using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AceAttitude.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly string CommentDoesntBelongToCourseErrorMessage = "Comment with id: {0} is not associated to course with id: {1}.";

        private readonly ApplicationDbContext context;

        public CommentRepository(ApplicationDbContext commentContext)
        {
            this.context = commentContext;
        }

        public Comment CreateComment(Comment comment, Course course)
        {
            comment.CreatedOn = DateTime.Now;
            comment.Course = course;
            context.Comments.Add(comment);

            context.SaveChanges();

            return comment;
        }

        public Comment DeleteComment(int commentId, int courseId)
        {
            Comment commentToDelete = GetById(commentId, courseId);
            commentToDelete.DeletedOn = DateTime.Now;

            context.SaveChanges();

            return commentToDelete;
        }

        public Comment GetById(int commentId, int courseId)
        {
            Comment comment = context.Comments
                .Include(comment => comment.Course)
                .Include(comment => comment.User)
                .Include(comment => comment.CommentLikes)
                .FirstOrDefault(c => c.Id == commentId && c.DeletedOn.HasValue == false)
             ?? throw new EntityNotFoundException($"Comment with id: {commentId} does not exist!");

            this.EnsureCommentBelongsToCourse(comment, courseId);

            return comment;
        }

        private CommentLike GetCommentLike(string userId, int commentId)
        {
            CommentLike commentLike = context.CommentLikes
                .FirstOrDefault(cl => cl.ApplicationUserId == userId && cl.CommentId == commentId)
                ?? new CommentLike { ApplicationUserId = userId, CommentId = commentId, IsLiked = false };

            if (!context.CommentLikes.Any(cl => cl.ApplicationUserId == userId && cl.CommentId == commentId))
            {
                context.Add(commentLike);
                context.SaveChanges();
            }

            return commentLike;
        }

        public Comment UpdateComment(int commentId, int courseId, string content)
        {
            Comment commentToUpdate = GetById(commentId, courseId);

            commentToUpdate.Content = content;
            commentToUpdate.ModifiedOn = DateTime.Now;

            context.SaveChanges();

            return commentToUpdate;
        }

        public Comment LikeComment(int commentId, int courseId, ApplicationUser user)
        {
            Comment commentToLike = GetById(commentId, courseId);

            CommentLike commentLike = this.GetCommentLike(user.Id, commentId);

            if (EnsureNoDuplicateLike(commentToLike, commentLike))
            {
                commentToLike.Likes++;
                commentLike.IsLiked = true;

                context.SaveChanges();
            }

            return commentToLike;
        }

        public void RemoveLike(Comment commentToUnlike, CommentLike commentLike)
        {
            commentLike.IsLiked = false;

            commentToUnlike.Likes--;

            context.SaveChanges();
        }

        public List<Comment> GetComments(Course course)
        {
            var comments = context.Comments
                .Include(c => c.User)
                .Where(c => c.DeletedOn.HasValue == false)
                .ToList();

            return comments;
        }

        private bool EnsureNoDuplicateLike(Comment commentToLike, CommentLike commentLike)
        {
            if (commentLike.IsLiked)
            {
                this.RemoveLike(commentToLike, commentLike);
                return false;
            }

            return true;
        }

        private void EnsureCommentBelongsToCourse(Comment comment, int courseId)
        {
            if (comment.CourseId != courseId)
            {
                throw new UnauthorizedOperationException(string.Format(CommentDoesntBelongToCourseErrorMessage, comment.Id, courseId));
            }
        }
    }
}
