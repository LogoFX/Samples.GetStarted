using Foundation;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Shared;
using UIKit;

namespace Samples.GetStarted.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private readonly ApplicationDelegate appDelegate = new ApplicationDelegate();

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();

            LoadApplication(ContainerContext.Resolver.Resolve<FormsApp>());

            return base.FinishedLaunching(app, options);
        }
    }
}
