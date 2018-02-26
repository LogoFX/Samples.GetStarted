using Caliburn.Micro.Xamarin.Forms;
using LogoFX.Bootstrapping;
using Solid.Bootstrapping;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;
using Xamarin.Forms;

namespace Samples.GetStarted.Forms.Launcher
{
    public class LogoFXApplication<TBootstrapper, TRootViewModel> : FormsApplication
        where TBootstrapper : BootstrapperBase
        where TRootViewModel : class
    {
        private readonly IDependencyRegistrator _dependencyRegistrator;

        public LogoFXApplication(TBootstrapper bootstrapper, IDependencyRegistrator dependencyRegistrator)
        {
            _dependencyRegistrator = dependencyRegistrator;
            Initialize();
            bootstrapper
                .Use(new RegisterCompositionModulesMiddleware<BootstrapperBase>())
                .Use(new RegisterRootViewModelMiddleware<BootstrapperBase, TRootViewModel>())
                .Initialize();            
            DisplayRootViewFor<TRootViewModel>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            _dependencyRegistrator.RegisterInstance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }
    }

    public class RegisterRootViewModelMiddleware<TBootstrapper, TRootViewModel> : IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator
        where TRootViewModel : class
    {
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator.RegisterSingleton<TRootViewModel>();
            return @object;
        }
    }

}
