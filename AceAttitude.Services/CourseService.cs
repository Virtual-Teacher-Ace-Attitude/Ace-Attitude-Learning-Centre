using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;
using AceAttitude.Common.Helpers.Contracts;

namespace AceAttitude.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUserRepository userRepository;

        private readonly IAuthHelper authHelper;

        private const string NotAccountOwnerErrorMessage = "Unable to continue, account owner required.";

        public CourseService(ICourseRepository courseRepository, IAuthHelper authHelper, IUserRepository userRepository)
        {
            this.courseRepository = courseRepository;
            this.authHelper = authHelper;
            this.userRepository = userRepository;
        }
        public Course CreateCourse(Course course, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            return courseRepository.CreateCourse(course);
        }

        public Course DeleteCourse(int id, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreatorOrAdmin(teacher, id);
            return courseRepository.DeleteCourse(id);
        }

        public Course GetById(int id)
        {

            return courseRepository.GetById(id);
        }


        public Course UpdateCourse(int id, Course course, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreatorOrAdmin(teacher, id);
            return courseRepository.UpdateCourse(id, course);
        }

        public List<Course> GetAll(string filterParam, string filterParamValue, string sortParam)
        {
            return courseRepository.GetFilteredCourses(filterParam, filterParamValue, sortParam);
        }

        public Course RateCourse(int id, decimal rating, Student student)
        {
            authHelper.EnsureStudentEnrolled(student, id);
            return courseRepository.RateCourse(id, rating, student);
        }

        public Course ReleaseCourse(int courseId, Teacher teacher)
        {
            authHelper.EnsureTeacherIsCourseCreator(teacher, courseId);
            return courseRepository.ReleaseCourse(courseId);
        }

        public Course ApplyForCourse(int courseId, Student student)
        {
            return this.courseRepository.ApplyForCourse(courseId, student);
        }

        public ICollection<Student> GetAppliedStudents(int courseId, Teacher teacher)
        {
            authHelper.EnsureTeacherIsCourseCreatorOrAdmin(teacher, courseId);

            return this.courseRepository.GetAppliedStudents(courseId);
        }

        public Student AdmitStudent(int courseId, string studentId, Teacher teacher)
        {
            authHelper.EnsureTeacherIsCourseCreatorOrAdmin(teacher, courseId);

            return this.courseRepository.AdmitStudent(courseId, studentId);
        }

        public ICollection<Course> GetAllTeacherCourses(string id, ApplicationUser requestUser)
        {
            authHelper.EnsureIdMatchingOrAdmin(id, requestUser, NotAccountOwnerErrorMessage);

            return this.courseRepository.GetAllTeacherCourses(id);
        }
    }
}
