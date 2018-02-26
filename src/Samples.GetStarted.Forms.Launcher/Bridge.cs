using Samples.GetStarted.Forms.Shared;

namespace Samples.GetStarted.Forms.Launcher
{
    public class Bridge
    {
        public static void Initialize()
        {
            ContainerContext.Registrator
                .AddInstance(ContainerContext.Registrator)
                .AddInstance(ContainerContext.Resolver)
                .AddSingleton<FormsApp>();
        }
    }
}
