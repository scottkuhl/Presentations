using FreshMvvm;
using Reminders.Data;
using Reminders.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Reminders.PageModels
{
    /// <summary>
    ///     Logic for the list of reminders user interface.
    /// </summary>
    public class ReminderListPageModel : FreshBasePageModel
    {
        private Repository _repository = FreshIOC.Container.Resolve<Repository>();
        private Reminder _selectedReminder = null;

        /// <summary>
        ///     Initialize the page model with a non-null list.
        /// </summary>
        public ReminderListPageModel()
        {
            Reminders = new ObservableCollection<Reminder>();
        }

        /// <summary>
        ///     Launch the reminder page for adding a new reminder.
        /// </summary>
        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<ReminderPageModel>();
                });
            }
        }

        /// <summary>
        ///     Launch the reminder page for editing an existing reminder.
        /// </summary>
        public ICommand EditCommand
        {
            get
            {
                return new Command(async (reminder) =>
                {
                    await CoreMethods.PushPageModel<ReminderPageModel>(reminder);
                });
            }
        }

        /// <summary>
        ///     List of reminders for data binding.
        /// </summary>
        public ObservableCollection<Reminder> Reminders { get; set; }

        /// <summary>
        ///     When a user selected a reminder from the list, mark it as
        ///     the selected reminder and then launch an edit.
        /// </summary>
        public Reminder Selected
        {
            get => _selectedReminder;
            set
            {
                _selectedReminder = value;
                if (value != null) EditCommand.Execute(value);
            }
        }

        /// <summary>
        ///     Load data when the view is appearing.
        /// </summary>
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            Load();
            base.ViewIsAppearing(sender, e);
        }

        /// <summary>
        ///     Load a list of reminders from storage.
        /// </summary>
        private void Load()
        {
            Reminders.Clear();
            var reminders = Task.Run(() => _repository.ReminderGetAllAsync()).Result;
            foreach (var reminder in reminders) Reminders.Add(reminder);
        }
    }
}