using System.Collections.Generic;
using System.Reflection;
using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Presentation.Shell.ViewModels;

namespace Samples.GetStarted.iOS
{
    public class ApplicationDelegate : LogoFXApplicationDelegate<FormsApp, Bootstrapper, ExtendedSimpleContainerAdapter>
    {
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return
                new[]
                {                    
                    //TODO: Needed for views to be registered - consider using this manually in the bootstrapper
                    typeof(ShellViewModel).Assembly
                };
        }
    }
}
