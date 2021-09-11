using EventManagement.Data;
using EventManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EventManagement.Pages.Host
{
    /// <summary>
    ///     Create an event.
    /// </summary>
    [Authorize]
    public class EventModel : BasePageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public EventModel(AppDbContext context, UserManager<AppUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public EventViewModel Event { get; set; } = new EventViewModel();

        /// <summary>
        ///     Load an existing or start a new record.
        /// </summary>
        /// <param name="id">Primary key for an existing record only.</param>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Only active users can host an event.
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            if (id != null)
            {
                // The id was not found.
                var evt = await _context.Events.FindAsync(id);
                if (evt == null) return NotFound();

                // Only the host can edit an event.
                if (evt.HostId != user.Id) return Forbid();

                // Map model to view model.
                Event.Id = evt.Id;
                Event.Title = evt.Title;
                Event.Description = evt.Description;
                Event.Start = evt.Start;
                Event.End = evt.End;
                Event.Location = evt.Location;
                Event.MaxCapacity = evt.MaxCapacity;
            }

            return Page();
        }

        /// <summary>
        ///     Create a new event.
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            // Only active users can host an event.
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            // Create a new event, or lookup the existing event.
            var evt = Event.Id > 0 ? await _context.Events.FindAsync(Event.Id) : new Event();
            if (evt == null) return NotFound();

            // Only the host can update the event.
            if (Event.Id != 0 && evt.HostId != user.Id) return Forbid();

            // Map view model to model.
            evt.HostId = user.Id;
            evt.Title = Event.Title;
            evt.Description = Event.Description;
            evt.Start = Event.Start;
            evt.End = Event.End;
            evt.Location = Event.Location;
            evt.MaxCapacity = Event.MaxCapacity;

            // Make sure everything is valid before saving.
            if (!ModelState.IsValid || !TryValidateModel(evt)) return Page();

            // Save the event.
            if (Event.Id == 0) _context.Events.Add(evt);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

        /// <summary>
        ///     Delete an existing record.
        /// </summary>
        /// <param name="id">Primary key.</param>
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            // Find the current user.
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            // Find the record to delete.
            var evt = await _context.Events.FindAsync(id);
            if (evt == null) return NotFound();

            // Only the host can delete the event.
            if (evt.HostId != user.Id) return Forbid();

            // Delete the record.
            _context.Events.Remove(evt);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }

    public class EventViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required."), StringLength(200, ErrorMessage = "Title can not be longer than 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required."), StringLength(2000, MinimumLength = 100, ErrorMessage = "Description must be between 100 and 2000 characters.")]
        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        [Required(ErrorMessage = "Location is required."), StringLength(200, ErrorMessage = "Location can not be longer than 200 characters.")]
        public string Location { get; set; }

        [Display(Name = "Max Capacity")]
        public short? MaxCapacity { get; set; }
    }
}