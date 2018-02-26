﻿using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using Solid.Practices.IoC;

namespace Samples.GetStarted.Forms.Infra
{
    public class Bridge<TApp, TBootstrapper, TContainerAdapter>
        where TApp : class
        where TBootstrapper : class
        where TContainerAdapter : IDependencyRegistrator, IDependencyResolver, IBootstrapperAdapter, new()
    {
        public static void Initialize()
        {
            ContainerContext<TContainerAdapter>.Registrator.RegisterInstance(ContainerContext<TContainerAdapter>.Registrator);
            ContainerContext<TContainerAdapter>.Registrator.RegisterInstance(ContainerContext<TContainerAdapter>.Resolver);
            ContainerContext<TContainerAdapter>.Registrator.RegisterSingleton<TApp>();
            ContainerContext<TContainerAdapter>.Registrator.RegisterSingleton<TBootstrapper>();
        }
    }
}
