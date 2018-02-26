using System.Collections.Generic;
using System.Reflection;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Presentation.Shell.ViewModels;

namespace Samples.GetStarted.iOS
{
    public class ApplicationDelegate : LogoFXApplicationDelegate<FormsApp, Bootstrapper>
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
