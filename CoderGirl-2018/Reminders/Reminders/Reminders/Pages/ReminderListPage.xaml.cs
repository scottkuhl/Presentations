using FreshMvvm;
using Xamarin.Forms.Xaml;

namespace Reminders.Pages
{
    /// <summary>
    ///     List of reminders page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderListPage : FreshBaseContentPage
    {
        public ReminderListPage()
        {
            InitializeComponent();
        }
    }
}