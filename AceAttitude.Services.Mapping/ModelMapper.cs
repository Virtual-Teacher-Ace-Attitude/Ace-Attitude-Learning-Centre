using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.DTO.Response;

namespace AceAttitude.Services.Mapping
{
    public class ModelMapper : IModelMapper
    {

        private readonly IParseHelper parseHelper;
        // Map to base entity
        public ModelMapper(IParseHelper parseHelper)
        {
            this.parseHelper = parseHelper;
        }
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

        public Lecture MapToLecture(LectureRequestDTO lectureRequestDTO, Course course)
        {
            return new Lecture
            {
                Title = lectureRequestDTO.Title,
                Description = lectureRequestDTO.Description,
                VideoFilePath = lectureRequestDTO.VideoFilePath,
                TextFilePath = lectureRequestDTO.TextFilePath,
                CreatedOn = DateTime.Now,
                Course = course,
                CourseId = course.Id,
            };
        }

        public Course MapToCourse(CourseRequestDTO courseRequestDTO)
        {
            return new Course
            {
                Title = courseRequestDTO.Title,
                Description = courseRequestDTO.Description,
                Level = parseHelper.ParseLevel(courseRequestDTO.Level),
                AgeGroup = parseHelper.ParseAge(courseRequestDTO.AgeGroup),
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
                StudentCourses = student.StudentCourses.Select(this.MapToStudentCoursesResponseDTO).ToList(),
                Ratings = student.Ratings.Select(this.MapToRatingResponseDTO).ToList(),
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
                CreatedCourses = teacher.CreatedCourses.Select(this.MapToCourseResponseDTO).ToList(),
            };
        }

        public LectureResponseDTO MapToLectureResponseDTO(Lecture lecture)
        {
            return new LectureResponseDTO
            {
                Course = lecture.Course.Title,
                Title = lecture.Title,
                Description = lecture.Description,
                VideoFilePath = lecture.VideoFilePath,
                TextFilePath = lecture.TextFilePath,
                CreatedOn = lecture.CreatedOn,
            };
        }

        public RatingResponseDTO MapToRatingResponseDTO(Rating rating)
        {
            return new RatingResponseDTO
            {
                Course = rating.Course.Title,
                Value = rating.Value,
                RatedOn = rating.CreatedOn,
            };
        }

        public StudentCoursesResponseDTO MapToStudentCoursesResponseDTO(StudentCourses studentCourses)
        {
            return new StudentCoursesResponseDTO
            {
                Course = studentCourses.Course.Title,
                IsCompleted = studentCourses.IsCompleted,
                EnrollDate = studentCourses.CreatedOn,
            };
        }

        public CourseResponseDTO MapToCourseResponseDTO(Course course)
        {
            return new CourseResponseDTO
            {
                Title = course.Title,
                Description = course.Description,
                IsDraft = course.IsDraft,
                Level = course.Level,
                AgeGroup = course.AgeGroup,
                CreatedOn = course.CreatedOn,
                StartingDate = course.StartingDate,
                IsCompleted = course.IsCompleted,
            };
        }
    }
}
