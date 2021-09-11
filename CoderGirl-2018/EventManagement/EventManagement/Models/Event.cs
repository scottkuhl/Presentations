using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    /// <summary>
    ///     An event created by an event host.
    /// </summary>
    public class Event : IValidatableObject
    {
        public int Id { get; set; }

        /// <summary>
        ///     User ID of the host.
        /// </summary>
        public int HostId { get; set; }

        /// <summary>
        ///     Name of the event.
        /// </summary>
        [Required, StringLength(200)]
        public string Title { get; set; }

        /// <summary>
        ///     Description of the event.
        /// </summary>
        [Required, StringLength(2000, MinimumLength = 100)]
        public string Description { get; set; }

        /// <summary>
        ///     When does the event start?
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        ///     When is the event expected to end?
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        ///     Where will the event be held?
        /// </summary>
        [Required, StringLength(200)]
        public string Location { get; set; }

        /// <summary>
        ///     Max number of attendees.
        /// </summary>
        public short? MaxCapacity { get; set; }

        /// <summary>
        ///     End date can't be before the start date.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (End <= Start) yield return new ValidationResult("The end date and time must be after the start date and time.");
        }

        #region Navigation Properties

        public AppUser Host { get; set; }

        #endregion Navigation Properties
    }
}
