using LogoFX.Client.Bootstrapping.Xamarin.Forms;
using Samples.GetStarted.Forms.Presentation.Shell.ViewModels;

namespace Samples.GetStarted.Forms.Launcher
{
    public class FormsApp : LogoFXApplication<ShellViewModel>
    {
        public FormsApp(Bootstrapper bootstrapper)
            : base(bootstrapper)
        {
        }
    }
}
