using LogoFX.Client.Bootstrapping.Xamarin.Forms;
using Samples.GetStarted.Forms.Presentation.Shell.ViewModels;
using Solid.Practices.IoC;

namespace Samples.GetStarted.Forms.Launcher
{
    public class FormsApp : LogoFXApplication<ShellViewModel>
    {
        public FormsApp(BootstrapperBase bootstrapper, IDependencyRegistrator dependencyRegistrator) :
        base(
            bootstrapper,
            dependencyRegistrator)
        {
        }
    }
}
