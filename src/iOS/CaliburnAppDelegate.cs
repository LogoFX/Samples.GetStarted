﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Threading;
using Caliburn.Micro;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Presentation.Shell.ViewModels;
using Samples.GetStarted.Forms.Shared;

namespace Samples.GetStarted.iOS
{
    public class CaliburnAppDelegate : CaliburnApplicationDelegate
    {
        public CaliburnAppDelegate()
        {
            Initialize();
        }

        protected override void Configure()
        {
            Bridge.Initialize();
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

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return
                new[]
                {                    
                    //TODO: Needed for views to be registered - consider using this manually in the bootstrapper
                    typeof(ShellViewModel).Assembly
                };
        }
    }
}