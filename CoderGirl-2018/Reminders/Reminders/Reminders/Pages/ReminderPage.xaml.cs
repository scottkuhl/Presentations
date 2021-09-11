using FreshMvvm;
using Xamarin.Forms.Xaml;

namespace Reminders.Pages
{
    /// <summary>
    ///     Detail page to view and edit a reminder.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderPage : FreshBaseContentPage
    {
        public ReminderPage()
        {
            InitializeComponent();
        }
    }
}