using LogoFX.Client.Bootstrapping.Xamarin.Forms;
using Solid.Practices.IoC;

namespace Samples.GetStarted.Forms.Launcher
{
    public class Bootstrapper: BootstrapperBase
    {
        public Bootstrapper(IDependencyRegistrator dependencyRegistrator)
            :base(dependencyRegistrator)
        {

        }

        public override string[] Prefixes
        {
            get => new[] { "Samples" };
        }

        public override System.Type[] AdditionalTypes => new System.Type[] { typeof(Samples.Client.Model.Module) };
    }
}
