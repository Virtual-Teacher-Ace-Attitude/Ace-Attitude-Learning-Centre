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

        private const string TeachersNotAwaitingApprovalErrorMessage = "No teachers are currently awaiting approval.";
        private const string TeacherAlreadyApprovedErrorMessage = "This teacher is already approved.";
        private const string TeacherAlreadyAdminErrorMessage = "This teacher is already an admin.";

        private const string UnableToDeleteAdminErrorMessage = "You are unable to delete other admins.";

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
                .FirstOrDefault(student => student.Id == id && student.DeletedOn.HasValue == false)
                ?? throw new EntityNotFoundException(string.Format(UserNotFoundErrorMessage, "Student", "ID: ", id));

            return student;
        }

        public Teacher GetTeacherById(string id)
        {
            var teacher = context.Teachers
                .Include(teacher => teacher.User)
                .Include(teacher => teacher.CreatedCourses)
                .FirstOrDefault(teacher => teacher.Id == id && teacher.DeletedOn.HasValue == false)
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
                .Where(teacher => teacher.IsApproved == false && teacher.DeletedOn.HasValue == false).ToList() 
                ?? throw new EntityNotFoundException(TeachersNotAwaitingApprovalErrorMessage);

            return unapprovedTeachers;
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

            Teacher teacher = this.modelMapper.MapToTeacherLite(user);
            teacher.IsApproved = false;

            context.Teachers.Add(teacher);

            context.SaveChanges();

            return user;
        }

        public ApplicationUser CreateStudent(ApplicationUser user)
        {
            context.Users.Add(user);

            Student student = this.modelMapper.MapToStudentLite(user);

            context.Students.Add(student);

            context.SaveChanges();

            return user;
        }

        public ApplicationUser Delete(string id)
        {
            ApplicationUser userToDelete = this.GetById(id);

            if (userToDelete.DeletedOn.HasValue)
            {
                throw new InvalidUserInputException(string.Format(UserNotFoundErrorMessage, "User", "id", id));
            }

            if (userToDelete.UserType == UserType.Admin)
            {
                throw new InvalidUserInputException(string.Format(UnableToDeleteAdminErrorMessage));
            }

            userToDelete.DeletedOn = DateTime.Now;

            if (userToDelete.UserType == UserType.Student)
            {
                Student studentToDelete = this.GetStudentById(id);
                studentToDelete.DeletedOn = DateTime.Now;
            }
            else if (userToDelete.UserType == UserType.Teacher)
            {
                Teacher teacherToDelete = this.GetTeacherById(id);
                teacherToDelete.DeletedOn = DateTime.Now;
            }

            context.SaveChanges();

            return userToDelete;
        }

        public ApplicationUser Update(string id, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public bool CheckEmailExists(string email)
        {
            return context.Users.Any(u => u.Email == email && u.DeletedOn.HasValue == false);
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
    }
}
