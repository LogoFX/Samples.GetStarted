namespace Samples.GetStarted.Launcher
{
    partial class App
    {
        public App()
        {            
            var bootstrapper = new AppBootstrapper();
            bootstrapper.Initialize();            
        }
    }
}
