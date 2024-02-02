﻿
using AceAttitude.Data.Models;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ICommentRepository
    {
        Comment CreateComment (Comment comment, Course course);

        Comment GetById (int id);

        Comment UpdateComment (int id, string content);

        Comment DeleteComment (int id);

        Comment LikeComment (int id, ApplicationUser user);


    }
}
