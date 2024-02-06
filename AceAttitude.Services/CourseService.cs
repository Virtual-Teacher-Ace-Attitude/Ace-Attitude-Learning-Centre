using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;
using Helpers;

namespace AceAttitude.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly AuthHelper authHelper;

        public CourseService(ICourseRepository courseRepository, AuthHelper authHelper)
        {
            this.courseRepository = courseRepository;
            this.authHelper = authHelper;
        }
        public Course CreateCourse(Course course, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            return courseRepository.CreateCourse(course);
        }

        public Course DeleteCourse(int id, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreator(teacher, id);
            return courseRepository.DeleteCourse(id);
        }

        public Course GetById(int id)
        {
            return courseRepository.GetById(id);
        }

        public Course UpdateCourse(int id, Course course, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreator(teacher, id);
            return courseRepository.UpdateCourse(id, course);
        }

        public List<Course> GetAll(string filterParam, string filterParamValue, string sortParam)
        {
            return courseRepository.GetFilteredCourses(filterParam, filterParamValue, sortParam);
        }

        public Course RateCourse(int id, Rating rating, Student student)
        {
            authHelper.EnsureStudentEnrolled(student, id);
            return courseRepository.RateCourse(id, rating);
        }
    }
}
