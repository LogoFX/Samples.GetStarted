using Android.App;
using Android.Content.PM;
using Android.OS;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Infra;
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

            LoadApplication(ContainerContext<ExtendedSimpleContainerAdapter>.Resolver.Resolve<FormsApp>());
        }
    }
}
