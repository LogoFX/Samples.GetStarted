using Caliburn.Micro.Xamarin.Forms;
using LogoFX.Bootstrapping;
using Samples.GetStarted.Forms.Presentation.Shell.ViewModels;
using Solid.Practices.IoC;
using Xamarin.Forms;

namespace Samples.GetStarted.Forms.Launcher
{
    public class FormsApp : FormsApplication
    {
        private readonly IDependencyRegistrator _dependencyRegistrator;

        public FormsApp(IDependencyRegistrator dependencyRegistrator)
        {
            Initialize();

            _dependencyRegistrator = dependencyRegistrator;
            var bootstrapper =
                new Bootstrapper(_dependencyRegistrator)
                .Use(new RegisterCompositionModulesMiddleware<Bootstrapper>());
            bootstrapper.Initialize();           
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            _dependencyRegistrator.RegisterInstance<INavigationService>(new NavigationPageAdapter(navigationPage));

        }
    }
}
