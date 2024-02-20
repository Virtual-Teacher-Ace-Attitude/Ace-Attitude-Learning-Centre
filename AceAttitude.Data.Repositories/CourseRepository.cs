using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Common.Helpers.Contracts;

using Microsoft.EntityFrameworkCore;

namespace AceAttitude.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private const string CourseNotFoundErrorMessage = "Course with id: {0} does not exist!";

        private const string CourseNotRatableErrorMessage = "Course with title: {0} is still ongoing and cannot be rated.";

        private const string CourseAlreadyReleasedErrorMessage = "Course with id: {0} is already released.";

        private const string StudentAlreadyAppliedErrorMessage = "You have already applied to course with id: {0}.";

        private const string NoStudentsAppliedErrorMessage = "No students are currently awaiting approval for this course.";

        private const string StudentCourseNotFoundErrorMessage = "Student with ID: {0} has not applied to course with ID: {1}.";

        private const string StudentAlreadyAdmitedErrorMessage = "Student with ID: {0} has already been admited to course with ID: {1}.";

        private readonly ApplicationDbContext context;

        private readonly IUserRepository userRepository;

        private readonly IParseHelper parseHelper;

        public CourseRepository(ApplicationDbContext context, IParseHelper parseHelper, IUserRepository userRepository)
        {
            this.context = context;
            this.parseHelper = parseHelper;
            this.userRepository = userRepository;
        }

        public Course CreateCourse(Course course)
        {
            course.CreatedOn = DateTime.Now;
            course.IsDraft = true;
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }

        private StudentCourses GetStudentCourse(int courseId, string studentId)
        {
            StudentCourses studentCourse = context
                .StudentCourses
                .Include(sc => sc.Course)
                .Include(sc => sc.Student)
                .FirstOrDefault(sc => sc.CourseId == courseId && sc.StudentId == studentId)
                ?? throw new EntityNotFoundException(string.Format(StudentCourseNotFoundErrorMessage, studentId, courseId));

            if (studentCourse.IsApproved)
            {
                throw new UnauthorizedOperationException(string.Format(StudentAlreadyAdmitedErrorMessage, studentId, courseId));
            }

            return studentCourse;
        }

        public Student AdmitStudent(int courseId, string studentId)
        {
            StudentCourses studentCourse = GetStudentCourse(courseId, studentId);

            studentCourse.IsApproved = true;

            context.SaveChanges();

            return this.userRepository.GetStudentById(studentId);
        }

        public ICollection<Course> GetAllTeacherCourses(string id)
        {
            ICollection<Course> courses = context.Courses
                .Include(course => course.Ratings)
                .Include(course => course.Teacher)
                .ThenInclude(teacher => teacher.User)
                .Where(course => course.TeacherId == id && course.DeletedOn.HasValue == false)
                .ToList();

            return courses;
        }

        public ICollection<Student> GetAppliedStudents(int courseId)
        {
            var appliedStudents = context.Students
                .Include(student => student.User)
                .Include(student => student.Ratings)
                .Include(student => student.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Where(student => student.IsPromoted == false
                && student.StudentCourses.Any(sc => sc.CourseId == courseId && sc.IsApproved == false)
                && student.User.DeletedOn.HasValue == false).ToList();

            this.EnsureCollectionNotEmpty(appliedStudents.Count, NoStudentsAppliedErrorMessage);

            return appliedStudents;
        }

        private void EnsureCollectionNotEmpty(int count, string errorMessage)
        {
            if (count == 0)
            {
                throw new EntityNotFoundException(errorMessage);
            }
        }

        public Course DeleteCourse(int id)
        {
            Course courseToDelete = GetById(id);
            courseToDelete.DeletedOn = DateTime.Now;
            context.SaveChanges();
            return courseToDelete;
        }

        public Course GetById(int id)
        {
            Course course = context.Courses
                .Include(course => course.Lectures)
                .Include(course => course.Comments)
                .ThenInclude(comment => comment.User)
                .Include(course => course.Ratings)
                .Include(course => course.Teacher)
                .ThenInclude(teacher => teacher.User)
                .FirstOrDefault(c => c.Id == id && c.DeletedOn.HasValue == false)
                ?? throw new EntityNotFoundException(string.Format(CourseNotFoundErrorMessage, id));
            return course;
        }

        public Course GetDraftCourse(int id)
        {
            Course course = context.Courses
                .Include(course => course.Lectures)
                .Include(course => course.Comments)
                .ThenInclude(comment => comment.User)
                .Include(course => course.Ratings)
                .Include(course => course.Teacher)
                .ThenInclude(teacher => teacher.User)
                .FirstOrDefault(c => c.Id == id && c.DeletedOn.HasValue == false)
                ?? throw new EntityNotFoundException(string.Format(CourseNotFoundErrorMessage, id));
            return course;
        }

        public Course ReleaseCourse(int courseId)
        {
            Course courseToRelease = GetById(courseId);

            this.EnsureCourseNotReleased(courseToRelease);

            courseToRelease.IsDraft = false;

            context.SaveChanges();

            return courseToRelease;
        }

        public Course ApplyForCourse(int courseId, Student student)
        {
            Course course = GetById(courseId);

            this.EnsureNotApplied(courseId, student);

            StudentCourses studentCourse = new StudentCourses { CourseId = courseId, StudentId = student.Id, IsCompleted = false, IsApproved = false };

            context.Add(studentCourse);

            context.SaveChanges();

            return course;
        }

        private void EnsureNotApplied(int courseId, Student student)
        {
            if (student.StudentCourses.Any(sc => sc.CourseId == courseId))
            {
                throw new UnauthorizedOperationException(string.Format(StudentAlreadyAppliedErrorMessage, courseId));
            }
        }

        public Course UpdateCourse(int id, Course course)
        {
            Course courseToUpdate = GetById(id);
            courseToUpdate.Title = course.Title;
            courseToUpdate.Description = course.Description;
            courseToUpdate.AgeGroup = course.AgeGroup;
            courseToUpdate.Level = course.Level;
            courseToUpdate.ModifiedOn = DateTime.Now;

            context.SaveChanges();

            return courseToUpdate;
        }

        private void EnsureCourseNotReleased(Course course)
        {
            if (course.IsDraft == false)
            {
                throw new UnauthorizedOperationException(string.Format(CourseAlreadyReleasedErrorMessage, course.Id));
            }
        }

        private Rating GetRating(int courseId, string studentId)
        {
            Rating rating = context.Ratings
                .FirstOrDefault(r => r.StudentId == studentId && r.CourseId == courseId)
                ?? new Rating { StudentId = studentId, CourseId = courseId, IsRated = false };

            if (!context.Ratings.Any(r => r.StudentId == studentId && r.CourseId == courseId))
            {
                context.Add(rating);
                context.SaveChanges();
            }

            return rating;
        }

        public Course RateCourse(int courseId, decimal value, Student student)
        {
            Course courseToRate = GetById(courseId);

            this.EnsureCourseCompleted(courseToRate);

            Rating rating = this.GetRating(courseId, student.Id);

            rating.Value = value;

            context.SaveChanges();

            return courseToRate;
        }

        private void EnsureCourseCompleted(Course course)
        {
            if (course.IsCompleted == false)
            {
                throw new UnauthorizedOperationException(string.Format(CourseNotRatableErrorMessage, course.Title));
            }
        }

        //public IQueryable<Course> GetAllDraft(Teacher teacher)
        //{
        //    IQueryable<Course> allDraftCourses = context.Courses.Where(c => c.DeletedOn.HasValue == false && c.IsDraft == false)
        //        .Include(course => course.Ratings)
        //        .Include(course => course.Teacher)
        //        .ThenInclude(teacher => teacher.User);

        //    return allDraftCourses;
        //}

        public IQueryable<Course> GetAll()
        {
            IQueryable<Course> allCourses = context.Courses.Where(c => c.DeletedOn.HasValue == false && c.IsDraft == false)
                .Include(course => course.Ratings)
                .Include(course => course.Teacher)
                .ThenInclude(teacher => teacher.User);

            return allCourses;
        }

        public List<Course> GetFilteredCourses(string filterParam, string filterParamValue, string sortParam)
        {
            IQueryable<Course> filteredCourses = FilterCourses(filterParam, filterParamValue);
            return SortCourses(sortParam, filteredCourses).ToList();
        }

        private IQueryable<Course> FilterCourses(string filterParam, string paramValue)
        {
            switch (filterParam.ToLower())
            {
                case "name":
                    return GetAll().Where(c => c.Title.Contains(paramValue));
                case "level":
                    Level level = parseHelper.ParseLevel(paramValue);
                    return GetAll().Where(c => c.Level == level);
                case "age":
                    AgeGroup age = parseHelper.ParseAge(paramValue);
                    return GetAll().Where(c => c.AgeGroup == age);
                case "teacher":
                    return GetAll().Where(c => c.Teacher.User.LastName == paramValue
                                            || c.Teacher.User.FirstName == paramValue);
                case "rating":
                    decimal rating = parseHelper.ParseRating(paramValue);
                    // Instead of calling the Rating() method, directly calculate the average rating in LINQ
                    return GetAll().Where(c => c.Ratings.Any() && c.Ratings.Select(r => r.Value).Average() >= rating);
                default:
                    return GetAll();

            }
        }

        private IQueryable<Course> SortCourses(string sortParam, IQueryable<Course> filteredCourses)
        {
            switch (sortParam.ToLower())
            {
                case "name":
                    return filteredCourses.OrderBy(c => c.Title);
                case "rating":
                    return filteredCourses.OrderByDescending(c => c.Ratings.Any() ? c.Ratings.Select(r => r.Value).Average() : -1);
                case "level":
                    return filteredCourses.OrderByDescending(c => c.Level);
                default:
                    return filteredCourses.OrderByDescending(c => c.StartingDate);
            }
        }
    }
}
