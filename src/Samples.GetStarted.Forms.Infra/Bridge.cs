using Samples.GetStarted.Forms.Shared;

namespace Samples.GetStarted.Forms.Launcher
{
    public class Bridge<TApp, TBootstrapper>
        where TApp : class
        where TBootstrapper : class
    {
        public static void Initialize()
        {
            ContainerContext.Registrator.RegisterInstance(ContainerContext.Registrator);
            ContainerContext.Registrator.RegisterInstance(ContainerContext.Resolver);
            ContainerContext.Registrator.RegisterSingleton<TApp>();
            ContainerContext.Registrator.RegisterSingleton<TBootstrapper>();
        }
    }
}
