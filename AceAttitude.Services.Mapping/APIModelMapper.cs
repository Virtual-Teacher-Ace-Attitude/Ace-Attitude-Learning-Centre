﻿using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.DTO.Response;

namespace AceAttitude.Services.Mapping
{
    public class APIModelMapper : IAPIModelMapper
    {

        private readonly IParseHelper parseHelper;
        // Map to base entities
        public APIModelMapper(IParseHelper parseHelper)
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

        public ApplicationUser MapToUser(UserUpdateRequestDTO userDTO)
        {
            return new ApplicationUser
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                PasswordHash = userDTO.Password,
                ModifiedOn = DateTime.Now,
            };
        }

        public Student MapToStudent(ApplicationUser user)
        {
            return new Student
            {
                User = user,
                ApplicationUserId = user.Id,
                Id = user.Id,
                IsPromoted = false,
                AwaitingPromotion = false,
            };
        }

        public Teacher MapToTeacher(ApplicationUser user)
        {
            return new Teacher
            {
                User = user,
                ApplicationUserId = user.Id,
                Id = user.Id,
                IsAdmin = false,
            };
        }

        public Lecture MapToLecture(LectureRequestDTO lectureRequestDTO)
        {
            return new Lecture
            {
                Title = lectureRequestDTO.Title,
                Description = lectureRequestDTO.Description,
                VideoFilePath = lectureRequestDTO.VideoFilePath,
                TextFilePath = lectureRequestDTO.TextFilePath,
                CreatedOn = DateTime.Now,
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

        public Comment MapToComment(CommentRequestDTO commentRequestDTO)
        {
            return new Comment
            {
                Content = commentRequestDTO.Content,
                Likes = 0,
            };
        }

        // Map to DTOs
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
                CreatedOn = student.User.CreatedOn,
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
                CreatedOn = teacher.User.CreatedOn,
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
                Level = course.Level.ToString(),
                AgeGroup = course.AgeGroup.ToString(),
                CreatedOn = course.CreatedOn,
                StartingDate = course.StartingDate,
                IsCompleted = course.IsCompleted,
                Rating = course.Rating() == -1 ? "N/A" : course.Rating().ToString("F2"),
            };
        }

        public CommentResponseDTO MapToCommentResponseDTO(Comment comment)
        {
            return new CommentResponseDTO
            {
                Content = comment.Content,
                User = comment.User.FirstName + " " + comment.User.LastName,
                Likes = comment.Likes,
                CreatedOn = comment.CreatedOn,
            };
        }
    }
}
