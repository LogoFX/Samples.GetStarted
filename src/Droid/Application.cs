﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Android.App;
using Android.Runtime;
using Samples.GetStarted.Forms.Launcher;
using Samples.GetStarted.Forms.Presentation.Shell.ViewModels;

namespace Samples.GetStarted.Droid
{
    [Application]
    public class Application : LogoFXApplication<FormsApp, Bootstrapper>
    {
        public Application(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return
                new[]
                {                    
                    //TODO: Needed for views to be registered - consider using this manually in the bootstrapper
                    Assembly.GetAssembly(typeof(ShellViewModel))
                };

        }
    }
}
