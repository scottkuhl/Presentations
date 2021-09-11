using Microsoft.AspNetCore.Identity;

namespace EventManagement.Models
{
    /// <summary>
    ///     Custom security roles.
    /// </summary>
    public class AppRole : IdentityRole<int>
    {
        public AppRole() { }

        public AppRole(string name)
        {
            Name = name;
        }
    }
}
