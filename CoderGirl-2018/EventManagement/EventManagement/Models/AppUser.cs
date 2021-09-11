using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    /// <summary>
    ///     Custom identity.
    /// </summary>
    public class AppUser : IdentityUser<int>
    {
        /// <summary>
        ///     First Name
        /// </summary>
        [PersonalData, Required, StringLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        ///     Last Name
        /// </summary>
        [PersonalData, Required, StringLength(20)]
        public string LastName { get; set; }

        /// <summary>
        ///     Combined First and Last Name
        /// </summary>
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        /// <summary>
        ///     Is the user wanting to play in games?
        /// </summary>
        public bool IsPlayer { get; set; }

        /// <summary>
        ///     Is the user wanting to run games?
        /// </summary>
        public bool IsDungeonMaster { get; set; }
    }
}
