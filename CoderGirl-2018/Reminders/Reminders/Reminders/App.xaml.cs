using FreshMvvm;
using Reminders.PageModels;

using Xamarin.Forms;

namespace Reminders
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = FreshPageModelResolver.ResolvePageModel<ReminderListPageModel>();
            MainPage = new FreshNavigationContainer(page);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}