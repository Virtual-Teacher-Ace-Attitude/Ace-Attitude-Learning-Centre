using AceAttitude.Data.Models;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.DTO.Response;

namespace AceAttitude.Services.Mapping
{
    public class ModelMapper : IModelMapper
    {
        // Map to base entity

        public ApplicationUser MapToUser(UserRegisterRequestDTO userDTO, string passwordHash)
        {
            return new ApplicationUser
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                PasswordHash = passwordHash,
                CreatedOn = DateTime.Now,
            };
        }

        public Student MapToStudent(ApplicationUser user)
        {
            return new Student
            {
                User = user,
                ApplicationUserId = user.Id,
                Id = user.Id,
                CreatedOn = DateTime.Now,
                Ratings = user.Student.Ratings,
                StudentCourses = user.Student.StudentCourses,
            };
        }

        public Student MapToStudentLite(ApplicationUser user)
        {
            return new Student
            {
                User = user,
                ApplicationUserId = user.Id,
                Id = user.Id,
                CreatedOn = DateTime.Now,
            };
        }

        public Teacher MapToTeacher(ApplicationUser user)
        {
            return new Teacher
            {
                User = user,
                ApplicationUserId = user.Id,
                Id = user.Id,
                CreatedOn = DateTime.Now,
                IsAdmin = user.Teacher.IsAdmin,
                IsApproved = user.Teacher.IsApproved,
                CreatedCourses = user.Teacher.CreatedCourses,
            };
        }

        public Teacher MapToTeacherLite(ApplicationUser user)
        {
            return new Teacher
            {
                User = user,
                ApplicationUserId = user.Id,
                Id = user.Id,
                CreatedOn = DateTime.Now,
                IsAdmin = false,
            };
        }

        // Map to DTO
        public UserResponseDTO MapToResponseUserDTO(ApplicationUser user, string userType)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedOn = user.CreatedOn,
                UserType = userType,
            };
        }

        public StudentResponseDTO MapToStudentResponseDTO(Student student)
        {
            return new StudentResponseDTO
            {
                UserType = "Student",
                Id = student.Id,
                Email = student.User.Email,
                FirstName = student.User.FirstName,
                LastName = student.User.LastName,
                CreatedOn = student.CreatedOn,
                StudentCourses = student.StudentCourses,
                Ratings = student.Ratings,
            };
        }

        public TeacherResponseDTO MapToTeacherResponseDTO(Teacher teacher)
        {
            return new TeacherResponseDTO
            {
                UserType = "Teacher",
                Id = teacher.Id,
                Email = teacher.User.Email,
                FirstName = teacher.User.FirstName,
                LastName = teacher.User.LastName,
                CreatedOn = teacher.CreatedOn,
                IsAdmin = teacher.IsAdmin,
                IsApproved = teacher.IsApproved,
                CreatedCourses = teacher.CreatedCourses,
            };
        }
    }
}
