using Samples.GetStarted.Forms.Shared;

namespace Samples.GetStarted.Forms.Launcher
{
    public class Bridge
    {
        public static void Initialize()
        {
            ContainerContext.Registrator.RegisterInstance(ContainerContext.Registrator);
            ContainerContext.Registrator.RegisterInstance(ContainerContext.Resolver);
            ContainerContext.Registrator.RegisterSingleton<FormsApp>();
        }
    }
}
