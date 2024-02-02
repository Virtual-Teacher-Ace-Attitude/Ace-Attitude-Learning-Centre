﻿using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Contracts;
using AceAttitude.Data.Repositories.Contracts;


namespace AceAttitude.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string UserNotFoundErrorMessage = "User with {0} {1} does not exist!";

        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ApplicationUser Create(ApplicationUser user)
        {
            context.Users.Add(user);

            context.SaveChanges();

            return user;
        }

        public ApplicationUser Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetByEmail(string email)
        {
            var user = context.Users.FirstOrDefault(user => user.Email == email && user.DeletedOn.HasValue == false)
                ?? throw new EntityNotFoundException(string.Format(UserNotFoundErrorMessage, "email:", email));

            return user;
        }

        public ApplicationUser Update(int id, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public bool CheckEmailExists(string email)
        {
            return context.Users.Any(u => u.Email == email && u.DeletedOn.HasValue == false);
        }
    }
}
