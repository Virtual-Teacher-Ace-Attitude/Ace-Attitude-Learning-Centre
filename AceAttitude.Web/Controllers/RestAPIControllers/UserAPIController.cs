using AceAttitude.Data.Models.Contracts;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.

        [HttpGet("{id}")]
        public IActionResult GetLectureById(int id)
        {
            return Ok(userService.GetById(id));
        }

        [HttpPost("")]
        public IActionResult CreateUser(IUser user)
        {
            var createdUser = userService.CreateUser(user);
            return StatusCode(StatusCodes.Status201Created, createdUser);
        }

        [HttpPut("{id}/edit")]
        public IActionResult UpdateUser(int id, [FromBody] IUser user)
        {
            var updatedUser = userService.UpdateUser(id, user);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var deletedUser = userService.DeleteUser(id);
            return Ok(deletedUser);
        }
    }
}