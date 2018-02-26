using Android.App;
using Android.Content.PM;
using Android.OS;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Shared;
using Xamarin.Forms.Platform.Android;

namespace Samples.GetStarted.Droid
{
    [Activity(Label = "Samples.GetStarted.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(ContainerContext.Resolver.Resolve<FormsApp>());
        }
    }
}
