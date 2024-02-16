using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseAPIController : ControllerBase
    {
        private const string InvalidCourseCreationErrorMessage = "Unable to create course, invalid input data!";

        private readonly ICourseService courseService;
        private readonly IAuthService authService;
        private readonly IAPIModelMapper modelMapper;

        public CourseAPIController(ICourseService courseService, IAuthService authService, IAPIModelMapper modelMapper)
        {
            this.courseService = courseService;
            this.authService = authService;
            this.modelMapper = modelMapper;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.
        [HttpGet("")]
        public IActionResult GetAll([FromQuery] string filterParam,
            [FromQuery] string filterParamValue, [FromQuery] string sortParam)
        {
            try
            {
                List<CourseResponseDTO> courses = courseService.GetAll(filterParam, filterParamValue, sortParam)
                    .Select(course => modelMapper.MapToCourseResponseDTO(course))
                    .ToList();
                return Ok(courses);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{courseId}")]
        public IActionResult GetCourseById(int courseId)
        {
            try
            {
                var course = courseService.GetById(courseId); 
                var responseDTO = modelMapper.MapToCourseResponseDTO(course);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult CreateCourse(CourseRequestDTO courseRequestDTO, [FromHeader] string credentials)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidCourseCreationErrorMessage);
                }

                Teacher teacher = authService.TryGetTeacher(credentials);
                Course course = modelMapper.MapToCourse(courseRequestDTO);
                course.TeacherId = teacher.Id;
                Course createdCourse = courseService.CreateCourse(course, teacher);
                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(createdCourse);
                return StatusCode(StatusCodes.Status201Created, responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPut("{courseId}/release")]
        public IActionResult ReleaseCourse(int courseId, [FromHeader] string credentials)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidCourseCreationErrorMessage);
                }

                Teacher teacher = authService.TryGetTeacher(credentials);
                
                Course releasedCourse = courseService.ReleaseCourse(courseId, teacher);

                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(releasedCourse);

                return StatusCode(StatusCodes.Status201Created, responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPut("{courseId}/apply")]
        public IActionResult ApplyForCourse(int courseId, [FromHeader] string credentials)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidCourseCreationErrorMessage);
                }

                Student student = authService.TryGetStudent(credentials);

                Course courseAppliedFor = courseService.ApplyForCourse(courseId, student);

                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(courseAppliedFor);

                return StatusCode(StatusCodes.Status201Created, responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpGet("{courseId}/students/applied")]
        public IActionResult GetAppliedStudents(int courseId, [FromHeader] string credentials)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidCourseCreationErrorMessage);
                }

                Teacher teacher = authService.TryGetTeacher(credentials);

                ICollection<Student> appliedStudents = courseService.GetAppliedStudents(courseId, teacher);

                ICollection<StudentResponseDTO> studentsDTO = appliedStudents.Select(this.modelMapper.MapToStudentResponseDTO).ToList();

                return StatusCode(StatusCodes.Status201Created, studentsDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPut("{courseId}/students/{studentId}/admit")]
        public IActionResult AdmitStudent([FromHeader] string credentials, int courseId, string studentId)
        {
            try
            {
                Teacher teacher = this.authService.TryGetTeacher(credentials);

                Student student = this.courseService.AdmitStudent(courseId, studentId, teacher);

                StudentResponseDTO studentResponseDTO = this.modelMapper.MapToStudentResponseDTO(student);

                return StatusCode(StatusCodes.Status200OK, studentResponseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("{courseId}")]
        public IActionResult UpdateCourse(int courseId, [FromBody] CourseRequestDTO courseRequestDTO, [FromHeader] string credentials)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidCourseCreationErrorMessage);
                }

                Teacher teacher = authService.TryGetTeacher(credentials);
                Course course = modelMapper.MapToCourse(courseRequestDTO);
                Course updatedCourse = courseService.UpdateCourse(courseId, course, teacher);
                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(updatedCourse);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPut("{courseId}/rate")]
        public IActionResult RateCourse(int courseId, [FromBody] decimal rating, [FromHeader] string credentials)
        {
            try
            {
                Student student = authService.TryGetStudent(credentials);
                Course ratedCourse = courseService.RateCourse(courseId, rating, student);
                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(ratedCourse);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);

            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpDelete("{courseId}")]
        public IActionResult DeleteCourse(int courseId, [FromHeader] string credentials)
        {
            try
            {
                Teacher teacher = authService.TryGetTeacher(credentials);
                Course deletedCourse = courseService.DeleteCourse(courseId, teacher);
                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(deletedCourse);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
