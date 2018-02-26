﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.Composition;
using Solid.Practices.Composition.Container;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;
using Solid.Practices.Modularity;

namespace Samples.GetStarted.Forms.Launcher
{
    public class BootstrapperBase : IInitializable,
        IExtensible<BootstrapperBase>,
        ICompositionModulesProvider,
        IHaveRegistrator,
        IAssemblySourceProvider
    {
        private readonly
            List<IMiddleware<BootstrapperBase>>
            _middlewares =
                new List<IMiddleware<BootstrapperBase>>();

        public BootstrapperBase(IDependencyRegistrator dependencyRegistrator)
        {
            Registrator = dependencyRegistrator;
            PlatformProvider.Current = new NetStandardPlatformProvider();
        }

        /// <summary>
        /// Gets the prefixes of the modules that will be used by the module registrator
        /// during bootstrapper configuration. Use this to implement efficient discovery.
        /// </summary>
        /// <value>
        /// The prefixes.
        /// </value>
        public virtual string[] Prefixes
        {
            get { return new string[] { }; }
        }

        /// <summary>
        /// Gets the list of modules that were discovered during bootstrapper configuration.
        /// </summary>
        /// <value>
        /// The list of modules.
        /// </value>
        public IEnumerable<ICompositionModule> Modules { get; private set; } = new ICompositionModule[] { };

        public IDependencyRegistrator Registrator { get; }

        private IEnumerable<Assembly> _assemblies;
        public IEnumerable<Assembly> Assemblies => _assemblies ??
            (_assemblies = System.AppDomain.CurrentDomain.GetAssemblies().FilterByPrefixes(Prefixes));

        private void InitializeCompositionModules()
        {
            ICompositionContainer<ICompositionModule> innerContainer = new SimpleCompositionContainer<ICompositionModule>(
                Assemblies,
                new ActivatorCreationStrategy());
            innerContainer.Compose();
            Modules = innerContainer.Modules.ToArray();
        }

        /// <summary>
        /// Extends the functionality by using the specified middleware.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <returns></returns>
        public BootstrapperBase Use(
            IMiddleware<BootstrapperBase> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }

        public void Initialize()
        {
            InitializeCompositionModules();
            MiddlewareApplier.ApplyMiddlewares(this, _middlewares);
        }
    }

    internal static class AssembliesExtensions
    {
        internal static IEnumerable<Assembly> FilterByPrefixes(this IEnumerable<Assembly> assemblies, string[] prefixes) => prefixes?.Length == 0
                ? assemblies
                : assemblies.Where(t => prefixes.Any(k => t.GetName().Name.StartsWith(k)));
    }
}