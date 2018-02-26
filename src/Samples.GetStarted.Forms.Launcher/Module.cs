using Samples.GetStarted.Forms.Presentation.Shell.ViewModels;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.GetStarted.Forms.Launcher
{
    public class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<ShellViewModel>();
        }
    }
}
