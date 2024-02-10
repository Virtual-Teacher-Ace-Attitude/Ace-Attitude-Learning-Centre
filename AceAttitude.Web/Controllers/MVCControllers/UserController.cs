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

        public UserController(IUserService userService, IAuthService authService, IMVCModelMapper modelMapper)
        {
            this.userService = userService;
            this.authService = authService;
            this.modelMapper = modelMapper;
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
                authService.Login(viewModel.Username, viewModel.Password);

                return RedirectToAction("Index", "Home");
            }
            catch (UnauthorizedOperationException ex)
            {
                ModelState.AddModelError("Username", ex.Message);
                ModelState.AddModelError("Password", ex.Message);

                return this.ForbiddenOperation(ex.Message, StatusCodes.Status401Unauthorized);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            authService.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var viewModel = new RegisterViewModel();

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

                ApplicationUser createdUser = this.authService.ValidateUserCanRegister(userToCreate, viewModel.UserType);
                _ = userService.Create(createdUser);

                if (viewModel.UserType == UserType.Student)
                {
					return RedirectToAction("Login", "User");
				}
                else
                {
					return RedirectToAction("Home", "Index");
				}
            }
            catch (DuplicateEntityException e)
            {
                return this.ForbiddenOperation(e.Message, StatusCodes.Status403Forbidden);
            }
        }

        private IActionResult ForbiddenOperation(string errorMessage, int statusCode)
        {
            Response.StatusCode = statusCode;
            ViewData["ErrorMessage"] = errorMessage;

            return View(viewName: "Error");
        }
    }
}
