using FreshMvvm;
using Reminders.Data;
using Reminders.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Reminders.PageModels
{
    /// <summary>
    ///     Logic for the reminder user interface.
    /// </summary>
    public class ReminderPageModel : FreshBasePageModel
    {
        private Reminder _reminder;
        private Repository _repository = FreshIOC.Container.Resolve<Repository>();

        /// <summary>
        ///     The reminder's date for data binding.
        /// </summary>
        public DateTime Date
        {
            get => _reminder.Date;
            set
            {
                _reminder.Date = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Delete the reminder from permanent storage.
        /// </summary>
        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _repository.ReminderDeleteAsync(_reminder);
                    await CoreMethods.PopPageModel(_reminder);
                });
            }
        }

        /// <summary>
        ///     The reminder's name for data binding.
        /// </summary>
        public string Name
        {
            get => _reminder.Name;
            set
            {
                _reminder.Name = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     The reminder's notes for data binding.
        /// </summary>
        public string Notes
        {
            get => _reminder.Notes;
            set
            {
                _reminder.Notes = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Save the reminder to permanent storage.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (_reminder.IsValid())
                    {
                        await _repository.ReminderSaveAsync(_reminder);
                        await CoreMethods.PopPageModel(_reminder);
                    }
                });
            }
        }

        /// <summary>
        ///     Called automatically by FreshMVVM when the page is navigated to.
        /// </summary>
        /// <param name="initData">
        ///     If supplied, use an existing model, otherwise start a new one.
        /// </param>
        public override void Init(object initData)
        {
            _reminder = initData as Reminder;
            if (_reminder == null) _reminder = new Reminder();
            base.Init(initData);
            RaisePropertyChanged(string.Empty);
        }
    }
}