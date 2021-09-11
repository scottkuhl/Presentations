using EventManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace EventManagement.Data
{
    /// <summary>
    ///     Database context extensions for testing.
    /// </summary>
    public static class AppDbContextExtensions
    {
        public static UserManager<AppUser> UserManager { get; set; }

        /// <summary>
        ///     Seed the database with starting data.
        /// </summary>
        public static void EnsureSeeded(this AppDbContext context)
        {
            if (UserManager.FindByEmailAsync("scott@eventmanagement.local").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Scott",
                    LastName = "Kuhl",
                    UserName = "scott@eventmanagement.local",
                    Email = "scott@eventmanagement.local",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "P@ssword1").GetAwaiter().GetResult();
            }
        }
    }
}
