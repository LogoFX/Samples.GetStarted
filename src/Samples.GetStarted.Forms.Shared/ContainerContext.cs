using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Solid.Practices.IoC;

namespace Samples.GetStarted.Forms.Shared
{
    public static class ContainerContext
    {
        private static readonly ExtendedSimpleContainerAdapter _instance = new ExtendedSimpleContainerAdapter();

        public static IDependencyRegistrator Registrator => _instance;
               
        public static IDependencyResolver Resolver => _instance;

        public static IBootstrapperAdapter Adapter => _instance;
    }
}
