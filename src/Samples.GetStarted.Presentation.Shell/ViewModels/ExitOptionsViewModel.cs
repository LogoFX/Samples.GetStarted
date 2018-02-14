using System.Windows.Input;
using Caliburn.Micro;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Shared;

namespace Samples.GetStarted.Presentation.Shell.ViewModels
{
    public class ExitOptionsViewModel : Screen
    {
        public ExitOptionsViewModel()
        {
            DisplayName = "Exit options";
        }

        public MessageResult Result { get; private set; }

        private ICommand _closeCommand;
        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = ActionCommand<MessageResult>.Do(r =>
        {
            Result = r;
            TryClose(true);
        }));
    }
}
