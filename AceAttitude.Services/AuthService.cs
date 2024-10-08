﻿using AceAttitude.Common.Exceptions;
using AceAttitude.Common.Helpers.Contracts;

using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;

using AceAttitude.Services.Contracts;

using Microsoft.AspNetCore.Http;

namespace AceAttitude.Services
{
	public class AuthService : IAuthService
	{
		private readonly string IncorrectCredentialsErrorMessage = "The email or password provided are incorrect!";

		private readonly string NotStudentErrorMessage = "The following action can only be performed by a student!";
		private readonly string NotTeacherErrorMessage = "The following action can only be performed by a teacher!";

		private readonly string UserNotLoggedInErrorMessage = "You need to be logged in to perform this action!";
		private readonly string UserNotAdminErrorMessage = "This action can only be performed by admins!";

		private readonly string TeacherNotApprovedErrorMessage = "This teacher profile either doesn't exist or hasn't been approved yet!";

		private const string CurrentUserKey = "CurrentUser";
		private readonly IHttpContextAccessor contextAccessor;

		private readonly IParseHelper parseHelper;

		private readonly IUserService userService;

		public AuthService(IUserService userService, IParseHelper parseHelper, IHttpContextAccessor contextAccessor)
		{
			this.userService = userService;
			this.parseHelper = parseHelper;
			this.contextAccessor = contextAccessor;
		}

		public ApplicationUser ValidateUserCanRegister(ApplicationUser user, UserType userType)
		{
			this.userService.CheckEmailExists(user.Email);

			user.UserType = userType;

			return user;
		}

		public ApplicationUser TryGetUser(string credentials)
		{
			try
			{
				credentials = this.parseHelper.ParseCredentials(credentials);

				string[] splitCredentials = credentials.Split('|');
				string email = splitCredentials[0];
				string password = splitCredentials[1];

				ApplicationUser user = userService.GetByEmail(email);

				if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
				{
					throw new UnauthorizedOperationException(IncorrectCredentialsErrorMessage);
				}

				return user;
			}
			catch (EntityNotFoundException)
			{
				throw new UnauthorizedOperationException(IncorrectCredentialsErrorMessage);
			}
		}

		public Student TryGetStudent(string credentials)
		{
			ApplicationUser user = this.TryGetUser(credentials);

			if (user.UserType != UserType.Student)
			{
				throw new UnauthorizedOperationException(NotStudentErrorMessage);
			}

			return this.userService.GetStudentById(user.Id);
		}

		public Teacher TryGetTeacher(string credentials)
		{
			ApplicationUser user = this.TryGetUser(credentials);

			if (user.UserType == UserType.Student)
			{
				throw new UnauthorizedOperationException(NotTeacherErrorMessage);
			}

			return this.userService.GetTeacherById(user.Id);
		}

		public string GeneratePasswordHash(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password);
		}

		// Front-End auth methods

		public ApplicationUser CurrentUser
		{
			get
			{
				string username = contextAccessor.HttpContext.Session.GetString(CurrentUserKey);
				if (username == null)
				{
					return null!;
				}

				return userService.GetByEmail(username);
			}
			private set
			{
				ApplicationUser user = value;
				if (user != null)
				{
					// add username to session
					contextAccessor.HttpContext.Session.SetString(CurrentUserKey, user.Email);
				}
				else
				{
					contextAccessor.HttpContext.Session.Remove(CurrentUserKey);
				}
			}
		}

		public bool EnsureUserLoggedIn()
		{
			bool loggedIn = contextAccessor.HttpContext.Session.Keys.Contains(CurrentUserKey);

			if (!loggedIn)
			{
				throw new UnauthorizedOperationException(UserNotLoggedInErrorMessage);
			}

			return loggedIn;
		}

		public void Login(string email, string password)
		{
			string credentials = email + '|' + password;
			CurrentUser = TryGetUser(credentials);

			if (CurrentUser.UserType == UserType.Teacher)
			{
				try
				{
					Teacher teacher = this.userService.GetTeacherById(CurrentUser.Id);
				}
				catch (EntityNotFoundException)
				{
					throw new UnauthorizedOperationException(TeacherNotApprovedErrorMessage);
				}
			}
		}

		public void Logout()
		{
			CurrentUser = null!;
		}

		public void EnsureUserAdmin()
		{
			if (CurrentUser != null)
			{
				if (CurrentUser.UserType != UserType.Admin)
				{
					throw new UnauthorizedOperationException(UserNotAdminErrorMessage);
				}
			}
		}
	}
}
