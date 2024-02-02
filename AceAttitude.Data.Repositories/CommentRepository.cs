using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;

namespace AceAttitude.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext commentContext;

        public CommentRepository(ApplicationDbContext commentContext)
        {
            this.commentContext = commentContext;
        }

        public Comment CreateComment(Comment comment, Course course)
        {
            comment.CreatedOn = DateTime.Now;
            comment.Course = course;
            commentContext.Comments.Add(comment);
            commentContext.SaveChanges();
            return comment;
        }

        public Comment DeleteComment(int id)
        {
            Comment commentToDelete = GetById(id);
            commentToDelete.DeletedOn = DateTime.Now;
            commentContext.SaveChanges();
            return commentToDelete;
        }

        public Comment GetById(int id)
        {
            Comment comment = commentContext.Comments.FirstOrDefault(c => c.Id == id && c.DeletedOn.HasValue == false)
             ?? throw new EntityNotFoundException($"Comment with id: {id} does not exist!");
            return comment;
        }



        public Comment UpdateComment(int id, string content)
        {
            Comment commentToUpdate = GetById(id);
            commentToUpdate.Content = content;
            commentToUpdate.ModifiedOn = DateTime.Now;
            commentContext.SaveChanges();
            return commentToUpdate;

        }

        public Comment LikeComment(int id, ApplicationUser user)
        {
            Comment commentToLike = GetById(id);
            commentToLike.Likes++;
            commentContext.CommentLikes.Add(new CommentLike()
            { ApplicationUserId = user.Id, User = user, IsLiked = true });

            commentContext.SaveChanges();

            return commentToLike;
        }

        public List<Comment> GetComments(Course course)
        {
            List<Comment> comments = course.Comments.Where(c => c.DeletedOn.HasValue == false).ToList();
            return comments;
        }
    }
}
