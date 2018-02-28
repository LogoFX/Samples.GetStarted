using JetBrains.Annotations;
using Samples.Client.Model.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Client.Model
{
    [UsedImplicitly]
    public class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator               
                .AddSingleton<IDataService, DataService>();
            //TODO:Add more services registration
        }
    }
}
