using Android.App;
using Android.Content.PM;
using Android.OS;
using FreshMvvm;
using Reminders.Droid.Services;
using Reminders.Data;

namespace Reminders.Droid
{
    [Activity(Label = "Reminders", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            // Make the repository available through dependency injection.
            var repository = new Repository(FileAccessHelper.GetLocalFilePath("Reminders.db3"));
            FreshIOC.Container.Register(repository);

            LoadApplication(new App());
        }
    }
}