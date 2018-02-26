using System;
using System.Collections.Generic;
using System.Windows.Threading;
using Caliburn.Micro;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Shared;

namespace Samples.GetStarted.iOS
{
    public class LogoFXApplicationDelegate<TApp, TBootstrapper> : CaliburnApplicationDelegate
        where TApp : class
        where TBootstrapper : class
    {
        public LogoFXApplicationDelegate()
        {
            Initialize();
        }

        protected override void Configure()
        {
            Bridge<TApp, TBootstrapper>.Initialize();
            Dispatch.Current = new PlatformDispatch();
        }

        protected override void BuildUp(object instance)
        {
            ContainerContext.Adapter.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return ContainerContext.Adapter.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return ContainerContext.Adapter.GetInstance(service, key);
        }
              
    }
}
