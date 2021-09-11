using SQLite;
using System;

namespace Reminders.Models
{
    /// <summary>
    ///     A reminder is a note to remember to do something.  Perhaps on a specific date.
    /// </summary>
    [Table(nameof(Reminder))]
    public class Reminder
    {
        /// <summary>
        ///     Optional date for the reminder.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Auto-incrementing record ID.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        /// <summary>
        ///     Required name of the reminder.
        /// </summary>
        [NotNull, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        ///     Optional additional notes about the reminder.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        ///     Is the reminder in a valid state to be saved?
        /// </summary>
        /// <returns>
        ///     True if the reminder has a name.
        /// </returns>
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }
    }
}