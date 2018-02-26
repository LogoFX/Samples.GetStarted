using System;
using System.Collections.Generic;
using System.Windows.Threading;
using Android.Runtime;
using Caliburn.Micro;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Shared;

namespace Samples.GetStarted.Droid
{
    public class LogoFXApplication<TApp, TBootstrapper> : CaliburnApplication
        where TApp : class
        where TBootstrapper : class
    {
        public LogoFXApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
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
