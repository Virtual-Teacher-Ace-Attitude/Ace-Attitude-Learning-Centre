﻿using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/courses/{courseId}/lectures")]
    public class LectureAPIController : ControllerBase
    {
        private readonly string InvalidLectureCreationErrorMessage = "Unable to create lecture, invalid input data!";

        private readonly IAuthService authService;
        private readonly IModelMapper modelMapper;

        private readonly ILectureService lectureService;
        private readonly ICourseService courseService;

        public LectureAPIController(ILectureService lectureService, IAuthService authService, IModelMapper modelMapper, ICourseService courseService)
        {
            this.lectureService = lectureService;
            this.courseService = courseService;

            this.authService = authService;
            this.modelMapper = modelMapper;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.

        [HttpGet("{lectureId}")]
        public IActionResult GetLectureById([FromHeader] string credentials, int lectureId, [FromRoute] int courseId)
        {
            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                LectureResponseDTO lectureResponseDTO = this.modelMapper.MapToLectureResponseDTO(lectureService.GetById(lectureId, courseId, user));

                return Ok(lectureResponseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult CreateLecture([FromHeader] string credentials, [FromBody] LectureRequestDTO lectureRequestDTO, [FromRoute] int courseId)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidLectureCreationErrorMessage);
                }

                Teacher teacher = authService.TryGetTeacher(credentials);

                Lecture createdLecture = lectureService.CreateLecture(lectureRequestDTO, courseId, teacher);

                createdLecture.CourseId = courseId;

                createdLecture.CreatedOn = DateTime.Now;

                LectureResponseDTO responseDTO = this.modelMapper.MapToLectureResponseDTO(createdLecture);

                return StatusCode(StatusCodes.Status201Created, responseDTO);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLecture([FromHeader] string credentials, int lectureId, [FromBody] LectureRequestDTO lectureRequestDto,
            [FromHeader] string userId, [FromQuery] int courseId)
        {
            try
            {
                Teacher teacher = authService.TryGetTeacher(credentials);

                Lecture lectureToUpdate = this.modelMapper.MapToLecture(lectureRequestDto, this.courseService.GetById(courseId));

                Lecture updatedLecture = lectureService.UpdateLecture(lectureId, courseId, lectureToUpdate, teacher);

                lectureToUpdate.ModifiedOn = DateTime.Now;

                LectureResponseDTO updatedLectureDto =  this.modelMapper.MapToLectureResponseDTO(updatedLecture);

                return Ok(updatedLectureDto);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLecture([FromHeader] string credentials, int id, [FromQuery] int courseId)
        {
            try
            {
                Teacher teacher = authService.TryGetTeacher(credentials);

                Lecture deletedLecture = lectureService.DeleteLecture(id, courseId, teacher);

                LectureResponseDTO lectureResponseDTO = this.modelMapper.MapToLectureResponseDTO(deletedLecture);

                return Ok(lectureResponseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }

        }
    }
}
