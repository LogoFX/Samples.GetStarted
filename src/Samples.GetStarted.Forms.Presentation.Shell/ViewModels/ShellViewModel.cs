using System.Threading.Tasks;
using System.Windows.Input;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using Samples.Client.Model.Contracts;

namespace Samples.GetStarted.Forms.Presentation.Shell.ViewModels
{
    public class ShellViewModel : EditableObjectViewModel<IWarehouseItem>
    {
        public ShellViewModel(IDataService dataService)
            : base(dataService.SingleItem)
        {

        }

        protected override async Task<bool> SaveMethod(IWarehouseItem model)
        {
            //TODO: Add custom saving logic - handle exceptions, etc.
            await Task.Delay(50);
            return true;
        }

        private ICommand _undoCommand;
        public ICommand UndoCommand => _undoCommand ?? (_undoCommand = ActionCommand.When(() => Model.CanUndo).Do(() => Model.Undo()).RequeryOnPropertyChanged(this, () => Model.CanUndo));

        private ICommand _redoCommand;
        public ICommand RedoCommand => _redoCommand ?? (_redoCommand = ActionCommand.When(() => Model.CanRedo).Do(() => Model.Redo()).RequeryOnPropertyChanged(this, () => Model.CanRedo));

        private ICommand _testCommand;
        public ICommand TestCommand => _testCommand ?? (_testCommand = ActionCommand.When(() => true).Do(() =>
        {

        }));
    }
}
