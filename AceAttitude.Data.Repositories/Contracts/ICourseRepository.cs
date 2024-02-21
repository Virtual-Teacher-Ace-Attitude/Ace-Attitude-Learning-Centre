using AceAttitude.Data.Models;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ICourseRepository
    {
        Course GetById(int id);

        Course GetDraftCourse(int id);

        ICollection<Course> GetAllTeacherCourses(string id);

        ICollection<Course> GetAllStudentCourses(string id);

        Course CreateCourse(Course course);

        Course UpdateCourse(int id, Course course);

        Course DeleteCourse(int id);

        Course RateCourse(int courseId, decimal rating, Student student);

        Course ReleaseCourse(int courseId);

        Course ApplyForCourse(int courseId, Student student);

        List<Course> GetFilteredCourses(string filterParam, string filterParamValue, string sortParam);

        ICollection<Student> GetAppliedStudents(int courseId);

        Student AdmitStudent(int courseId, string studentId);

        ICollection<Course> GetHomeCourses();

        ICollection<StudentCourses> GetUnapprovedStudentCourses(int id);

        public StudentCourses GetStudentCourse(int studentCoursesId);
    }
}
