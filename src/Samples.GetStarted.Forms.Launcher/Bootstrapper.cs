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
            get
            {
                return new [] { "Samples.GetStarted" };
            }
        }
    }
}
