﻿using Foundation;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Infra;
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

            LoadApplication(ContainerContext<ExtendedSimpleContainerAdapter>.Resolver.Resolve<FormsApp>());

            return base.FinishedLaunching(app, options);
        }
    }
}
