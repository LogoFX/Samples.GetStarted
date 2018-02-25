using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Mvvm.Commanding;
using Samples.GetStarted.WPF.Launcher;

namespace Samples.GetStarted.Launcher
{
    partial class App
    {
        public App()
        {            
            var bootstrapper = new AppBootstrapper();            
            bootstrapper
                .UseResolver()
                .UseCommanding()
                .Initialize();            
        }
    }
}
