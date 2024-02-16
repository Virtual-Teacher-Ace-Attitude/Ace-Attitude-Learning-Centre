﻿using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface ICourseService
    {
        Course GetById(int id);

        Course CreateCourse(Course course, Teacher teacher);

        Course DeleteCourse(int id, Teacher teacher);

        Course UpdateCourse(int id, Course course, Teacher teacher);

        Course ReleaseCourse(int courseId, Teacher teacher);

        Course ApplyForCourse(int courseId, Student student);

        List<Course> GetAll(string filterParam, string filterParamValue, string sortParam);

        Course RateCourse(int id, decimal rating, Student student);

        public ICollection<Student> GetAppliedStudents(int courseId, Teacher teacher);

        public Student AdmitStudent(int courseId, string studentId, Teacher teacher);
    }
}
