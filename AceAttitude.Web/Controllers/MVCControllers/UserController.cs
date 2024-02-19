using AceAttitude.Common.Exceptions;

using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;

using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.MVCControllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;
        private readonly IMVCModelMapper modelMapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserController(IUserService userService, IAuthService authService, IMVCModelMapper modelMapper, IWebHostEnvironment webHostEnvironment)
        {
            this.userService = userService;
            this.authService = authService;
            this.modelMapper = modelMapper;
            this.webHostEnvironment = webHostEnvironment;
        }

		[HttpGet]
		public IActionResult Login()
		{
			var viewModel = new LoginViewModel();

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			try
			{
				authService.Login(viewModel.Email, viewModel.Password);

				return RedirectToAction("Index", "Home");
			}
			catch (UnauthorizedOperationException e)
			{
				ModelState.AddModelError("Email", e.Message);
				ModelState.AddModelError("Password", e.Message);

				return this.ForbiddenOperation(e.Message, StatusCodes.Status401Unauthorized);
			}
			catch (EntityNotFoundException e)
			{
				return this.ForbiddenOperation(e.Message, StatusCodes.Status401Unauthorized);
			}
		}

		[HttpGet]
        public IActionResult Logout()
        {
            authService.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register(bool isStudent)
        {
            var viewModel = new RegisterViewModel();
            viewModel.IsStudent = isStudent;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                string passwordHash = this.authService.GeneratePasswordHash(viewModel.Password);

                ApplicationUser userToCreate = this.modelMapper.MapToUser(viewModel, passwordHash);

                UserType userType = viewModel.IsStudent ? UserType.Student : UserType.Teacher;

                if (userType == UserType.Student)
                {
                    ApplicationUser createdUser = this.authService.ValidateUserCanRegister(userToCreate, userType);
                    _ = userService.CreateStudent(createdUser);

                    return RedirectToAction("Login", "User");
                }
                else
                {
                    ApplicationUser createdUser = this.authService.ValidateUserCanRegister(userToCreate, userType);
                    _ = userService.CreateTeacher(createdUser);

                    // Add view for created teacher to advise that to wait for approval
                    return RedirectToAction("TeacherConfirmation", "User");
                }
            }
            catch (DuplicateEntityException e)
            {
                return this.ForbiddenOperation(e.Message, StatusCodes.Status403Forbidden);
            }
        }

        [HttpGet]
        public IActionResult TeacherConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details([FromRoute] string id)
        {
            try
            {
                this.authService.EnsureUserLoggedIn();
                ApplicationUser requestUser = this.authService.CurrentUser;

                ApplicationUser profileUser = userService.ViewUserProfile(id, requestUser);
                UserViewModel userViewModel = this.modelMapper.MapToUserViewModel(profileUser);
                return View(userViewModel);
            }
            catch (UnauthorizedOperationException e)
            {
                return this.ForbiddenOperation(e.Message, StatusCodes.Status401Unauthorized);
            }
            catch (EntityNotFoundException e)
            {
                return this.ForbiddenOperation(e.Message, StatusCodes.Status404NotFound);
            }
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit([FromRoute] string id)
        {
            try
            {
                ApplicationUser requestUser = authService.CurrentUser;

                ApplicationUser userToEdit = this.userService.ViewUserProfile(id, requestUser);

                EditUserViewModel userEditViewModel = this.modelMapper.MapToEditUserViewModel(userToEdit);

                return View(userEditViewModel);
            }
            catch (EntityNotFoundException e)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = e.Message;

                return View("Error");
            }
            catch (UnauthorizedOperationException e)
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
                ViewData["ErrorMessage"] = e.Message;

                return View("Error");
            }
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit([FromRoute] string id, EditUserViewModel userEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userEditViewModel);
            }

            var requestUser = authService.CurrentUser;
            var userToUpdate = this.modelMapper.MapToUser(userEditViewModel);
            userToUpdate.PasswordHash = this.authService.GeneratePasswordHash(userEditViewModel.Password);
            var createdUser = userService.Update(id, requestUser, userToUpdate);

            return RedirectToAction("Details", "User", new { id = createdUser.Id });
        }

        [HttpPost]
        public IActionResult ApplyForTeacher([FromRoute]string id)
        {
            try
            {
                ApplicationUser requestUser = this.authService.CurrentUser;

                ApplicationUser applyingStudent = this.userService.GetById(id);
                Student appliedUser = this.userService.ApplyForTeacher(applyingStudent);

                return RedirectToAction("TeacherConfirmation", "User");
            }
            catch (EntityNotFoundException e)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = e.Message;

                return View("Error");
            }
            catch (UnauthorizedOperationException e)
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
                ViewData["ErrorMessage"] = e.Message;

                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult UploadProfilePicture(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    // Handle case when no file is selected
                    return BadRequest("No file selected.");
                }

                // Check if the file is an image and if it's either PNG or JPEG
                if (!IsImage(file) || !IsAllowedFileType(file.FileName))
                {
                    return BadRequest("Invalid file format. Only PNG and JPEG images are allowed.");
                }

                // Generate unique file name
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Path where the file will be saved
                string filePath = Path.Combine(this.webHostEnvironment.WebRootPath, "images","profile-pictures", fileName);

                // Save the file to wwwroot/profile-pictures folder
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Update user's profile picture path in your data store
                ApplicationUser requestUser = this.authService.CurrentUser;
                // Assuming you have a method like UpdateProfilePicturePath in your userService
                // Update the user's profile picture path with the relativeFilePath
                string dataBasePath = filePath;
                userService.UpdateProfilePicturePath(dataBasePath, requestUser.Id);

                // Return success response with the URL of the uploaded image
                string imageUrl = Url.Content(filePath); // Convert to URL
                return Ok(new { imageUrl });
            }
            catch (Exception ex)
            {
                // Handle any errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private bool IsImage(IFormFile file)
        {
            // Check if the file content type starts with "image/"
            return file.ContentType.StartsWith("image/");
        }

        private bool IsAllowedFileType(string fileName)
        {
            // Check if the file extension is either PNG or JPEG
            string ext = Path.GetExtension(fileName).ToLower();
            return ext == ".png" || ext == ".jpg" || ext == ".jpeg";
        }


        private IActionResult ForbiddenOperation(string errorMessage, int statusCode)
        {
            Response.StatusCode = statusCode;
            ViewData["ErrorMessage"] = errorMessage;

            return View(viewName: "Error");
        }
    }
}
