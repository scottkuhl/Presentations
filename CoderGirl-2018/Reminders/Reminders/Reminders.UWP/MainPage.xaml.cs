using FreshMvvm;
using Reminders.Data;
using Reminders.UWP.Services;

namespace Reminders.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Make the repository available through dependency injection.
            var repository = new Repository(FileAccessHelper.GetLocalFilePath("Reminders.db3"));
            FreshIOC.Container.Register(repository);

            LoadApplication(new Reminders.App());
        }
    }
}