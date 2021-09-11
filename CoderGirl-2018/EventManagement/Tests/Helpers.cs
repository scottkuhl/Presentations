using EventManagement.Data;
using EventManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Tests
{
    /// <summary>
    ///     Helper methods for testing.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        ///     Create a starting in memory based database context.
        /// </summary>
        /// <returns>In Memory Database Context</returns>
        public static AppDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        /// <summary>
        ///     Setup a Razor Page model for testing.
        /// </summary>
        /// <param name="pageModel">Page model to test.</param>
        /// <param name="userName">Name of the user under test.</param>
        /// <param name="userRole">Role of the user under test.</param>
        /// <returns>Testable page model.</returns>
        public static PageModel CreatePageModel(PageModel pageModel, string userName = null, string userRole = null)
        {
            var httpContext = new DefaultHttpContext();
            if (userName != null)
            {
                var principle = new Mock<ClaimsPrincipal>();
                if (!string.IsNullOrEmpty(userRole)) principle.Setup(x => x.IsInRole(userRole)).Returns(true);
                principle.Name = userName;
                principle.SetupGet(x => x.Identity.Name).Returns(principle.Name);
                httpContext.User = principle.Object;
            }

            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext) { ViewData = viewData };

            pageModel.PageContext = pageContext;
            pageModel.TempData = tempData;
            pageModel.Url = new UrlHelper(actionContext);

            return pageModel;
        }

        /// <summary>
        ///     Fill a string with x's.
        /// </summary>
        /// <param name="length">Length of the string.</param>
        /// <returns>string value of <paramref name="length"/> characters long.</returns>
        /// <remarks>
        ///     This makes it easier to test properties with a minimum length requirement.
        /// </remarks>
        public static string FillString(int length)
        {
            var result = string.Empty;
            for (var i = 0; i < length; i++)
            {
                result += "x";
            }
            return result;
        }

        /// <summary>
        ///     Create a fake user manager.
        /// </summary>
        /// <typeparam name="TUser">AppUser</typeparam>
        /// <param name="user">User to populate the manager.</param>
        /// <returns>Testable user manager that does not access a database.</returns>
        /// <example>
        ///     var userManager = Helpers.MockUserManager(new AppUser { Id = 1, UserName = "Test" }).Object;
        /// </example>
        public static Mock<UserManager<TUser>> MockUserManager<TUser>(TUser user) where TUser : AppUser
        {
            var users = user != null ? new List<TUser> { user } : new List<TUser>();
            var userManager = Helpers.MockUserManager(users);
            userManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
            return userManager;
        }

        /// <summary>
        ///     Create a fake user manager.
        /// </summary>
        /// <typeparam name="TUser">AppUser</typeparam>
        /// <param name="users">List of users to populate the manager.</param>
        /// <returns>Testable user manager that does not access a database.</returns>
        /// <example>
        ///     var userManager = Helpers.MockUserManager(new List<AppUser>
        ///     {
        ///         new AppUser { Id = 1, UserName = "Test1" },
        ///         new AppUser { Id = 1, UserName = "Test1" }
        ///     }).Object;
        /// </example>
        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> users) where TUser : AppUser
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => users.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            foreach (var user in users)
            {
                mgr.Setup(x => x.FindByEmailAsync(user.Email)).ReturnsAsync(user);
                mgr.Setup(x => x.FindByIdAsync(user.Id.ToString())).ReturnsAsync(user);
                mgr.Setup(x => x.FindByNameAsync(user.UserName)).ReturnsAsync(user);
            }

            return mgr;
        }

        /// <summary>
        ///     Validate a model.
        /// </summary>
        /// <param name="model">Model to validate.</param>
        /// <returns>List of invalid results.</returns>
        public static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}