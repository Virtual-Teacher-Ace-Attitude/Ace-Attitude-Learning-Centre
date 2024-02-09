using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Mapping.Contracts;

using Microsoft.EntityFrameworkCore;

namespace AceAttitude.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string UserNotFoundErrorMessage = "{0} with {1} {2} does not exist!";

        private const string StudentAlreadyAppliedErrorMessage = "This student has already applied to be a teacher!";
        private const string StudentAlreadyApprovedErrorMessage = "This student has already been approved for teacher.";
        private const string StudentNotAwaitingApprovalErrorMessage = "This student has not applied to become a teacher.";

        private const string TeachersNotAwaitingApprovalErrorMessage = "No teachers are currently awaiting approval.";
        private const string TeacherAlreadyApprovedErrorMessage = "This teacher is already approved.";

        private const string TeacherAlreadyAdminErrorMessage = "This teacher is already an admin.";

        private const string UnableToDeleteAdminErrorMessage = "You are unable to delete other admins.";
        private const string UnableToEditAdminErrorMessage = "You are unable to edit the profile of other admins.";


        private readonly ApplicationDbContext context;
        private readonly IModelMapper modelMapper;

        public UserRepository(ApplicationDbContext context, IModelMapper modelMapper)
        {
            this.context = context;
            this.modelMapper = modelMapper;
        }
        public ApplicationUser GetById(string id)
        {
            var user = context.Users.FirstOrDefault(user => user.Id == id && user.DeletedOn.HasValue == false)
                ?? throw new EntityNotFoundException(string.Format(UserNotFoundErrorMessage, "User", "ID: ", id));

            return user;
        }

        public Student GetStudentById(string id)
        {
            var student = context.Students
                .Include(student => student.User)
                .Include(student => student.Ratings)
                .Include(student => student.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefault(student => student.Id == id && student.User.DeletedOn.HasValue == false && student.IsPromoted == false)
                ?? throw new EntityNotFoundException(string.Format(UserNotFoundErrorMessage, "Student", "ID: ", id));

            return student;
        }

        public Teacher GetTeacherById(string id)
        {
            var teacher = context.Teachers
                .Include(teacher => teacher.User)
                .Include(teacher => teacher.CreatedCourses)
                .FirstOrDefault(teacher => teacher.Id == id && teacher.User.DeletedOn.HasValue == false && teacher.IsApproved)
                ?? throw new EntityNotFoundException(string.Format(UserNotFoundErrorMessage, "Teacher", "ID: ", id));

            return teacher;
        }

        public ApplicationUser GetByEmail(string email)
        {
            var user = context.Users.FirstOrDefault(user => user.Email == email && user.DeletedOn.HasValue == false)
                ?? throw new EntityNotFoundException(string.Format(UserNotFoundErrorMessage, "User", "email:", email));

            return user;
        }

        public ICollection<Teacher> GetUnapprovedTeachers()
        {
            var unapprovedTeachers = context.Teachers
                .Include(teacher => teacher.User)
                .Include(teacher => teacher.CreatedCourses)
                .Where(teacher => teacher.IsApproved == false && teacher.User.DeletedOn.HasValue == false).ToList()
                ?? throw new EntityNotFoundException(TeachersNotAwaitingApprovalErrorMessage);

            return unapprovedTeachers;
        }

        public ICollection<Student> GetUnapprovedStudents()
        {
            var unapprovedStudents = context.Students
                .Include(student => student.User)
                .Include(student => student.Ratings)
                .Include(student => student.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Where(student => student.IsPromoted == false && student.AwaitingPromotion == true && student.User.DeletedOn.HasValue == false).ToList()
                ?? throw new EntityNotFoundException(TeachersNotAwaitingApprovalErrorMessage);

            return unapprovedStudents;
        }

        public ApplicationUser Create(ApplicationUser user)
        {
            context.Users.Add(user);

            context.SaveChanges();

            return user;
        }

        public ApplicationUser CreateTeacher(ApplicationUser user)
        {
            context.Users.Add(user);

            Teacher teacher = this.modelMapper.MapToTeacher(user);
            teacher.IsApproved = false;

            context.Teachers.Add(teacher);

            context.SaveChanges();

            return user;
        }

        public ApplicationUser CreateStudent(ApplicationUser user)
        {
            context.Users.Add(user);

            Student student = this.modelMapper.MapToStudent(user);

            context.Students.Add(student);

            context.SaveChanges();

            return user;
        }

        public ApplicationUser Delete(string id)
        {
            ApplicationUser userToDelete = this.GetById(id);

            this.EnsureNotDeleted(userToDelete.DeletedOn.HasValue, string.Format(UserNotFoundErrorMessage, "User", "id", id));
            this.EnsureNotAdmin(userToDelete.UserType, UnableToDeleteAdminErrorMessage);

            userToDelete.DeletedOn = DateTime.Now;

            context.SaveChanges();

            return userToDelete;
        }

        public ApplicationUser Update(string id, ApplicationUser userToUpdate)
        {
            ApplicationUser userToEdit = this.GetById(id);

            this.EnsureNotDeleted(userToEdit.DeletedOn.HasValue, string.Format(UserNotFoundErrorMessage, "User", "id", id));
            this.EnsureNotAdmin(userToEdit.UserType, UnableToEditAdminErrorMessage);

            userToEdit.PasswordHash = userToUpdate.PasswordHash;
            userToEdit.FirstName = userToUpdate.FirstName;
            userToEdit.LastName = userToUpdate.LastName;
            userToEdit.PictureFilePath = userToUpdate.PictureFilePath;

            context.SaveChanges();

            return userToEdit;
        }

        public bool CheckEmailExists(string email)
        {
            return context.Users.Any(u => u.Email == email && u.DeletedOn.HasValue == false);
        }

        public Student ApplyForTeacher(string id)
        {
            Student student = this.GetStudentById(id);

            if (student.AwaitingPromotion)
            {
                throw new UnauthorizedOperationException(StudentAlreadyAppliedErrorMessage);
            }

            student.AwaitingPromotion = true;

            context.SaveChanges();

            return student;
        }

        public Teacher ApproveTeacher(string id)
        {
            Teacher teacher = this.GetTeacherById(id);

            if (teacher.IsApproved)
            {
                throw new InvalidUserInputException(TeacherAlreadyApprovedErrorMessage);
            }

            teacher.IsApproved = true;
            context.SaveChanges();

            return teacher;
        }

        public Teacher PromoteStudent(string id)
        {
            ApplicationUser user = this.GetById(id);

            Student student = this.GetStudentById(id);

            if (student.IsPromoted)
            {
                throw new UnauthorizedOperationException(StudentAlreadyApprovedErrorMessage);
            }

            if (student.AwaitingPromotion == false)
            {
                throw new UnauthorizedOperationException(StudentNotAwaitingApprovalErrorMessage);
            }

            student.IsPromoted = true;
            student.AwaitingPromotion = false;

            Teacher newTeacher = this.modelMapper.MapToTeacher(user);

            context.SaveChanges();

            return newTeacher;
        }

        public Teacher PromoteAdmin(string id)
        {
            Teacher teacher = this.GetTeacherById(id);

            if (teacher.IsAdmin)
            {
                throw new InvalidUserInputException(TeacherAlreadyAdminErrorMessage);
            }

            teacher.IsAdmin = true;
            teacher.User.UserType = UserType.Admin;
            context.SaveChanges();

            return teacher;
        }

        private bool EnsureNotDeleted(bool isDeleted, string message)
        {
            if (isDeleted)
            {
                throw new EntityNotFoundException(message);
            }

            return true;
        }

        private bool EnsureNotAdmin(UserType userType, string message)
        {
            if (userType == UserType.Admin)
            {
                throw new UnauthorizedOperationException(message);
            }

            return true;
        }
    }
}
