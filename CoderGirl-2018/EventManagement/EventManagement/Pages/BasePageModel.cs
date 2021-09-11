using EventManagement.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventManagement.Pages
{
    /// <summary>
    ///     Common functionality for all page models.
    /// </summary>
    public class BasePageModel : PageModel
    {
        /// <summary>
        ///     Entity Framework database context.
        /// </summary>
        protected readonly AppDbContext _context;

        public BasePageModel(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Set this during testing to force validation to pass or fail.
        /// </summary>
        /// <remarks>
        ///     TryValidateModel() is a static method on the PageModel that fails during unit testing.
        ///     Unlike MVC Controllers, ObjectValidator is not exposed for us to mock.
        /// </remarks>
        /// <seealso cref="https://github.com/aspnet/Mvc/issues/3586"/>
        public bool? TryValidateModelResult { get; set; }

        /// <summary>
        ///     Validates the specified <paramref name="model"/> instance.
        /// </summary>
        /// <param name="model">The model to validate.</param>
        /// <returns>true if the ModelState is valid; false otherwise.</returns>
        /// <remarks>
        ///     Short circuits if <see cref="TryValidateModelResult"/> is set.
        /// </remarks>
        public override bool TryValidateModel(object model)
        {
            if (TryValidateModelResult.HasValue) return TryValidateModelResult.Value;
            return base.TryValidateModel(model);
        }
    }
}
