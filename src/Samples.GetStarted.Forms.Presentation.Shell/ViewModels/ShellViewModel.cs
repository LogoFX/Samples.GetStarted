using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.Notifications;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using Samples.Client.Model.Contracts;

namespace Samples.GetStarted.Forms.Presentation.Shell.ViewModels
{
    public class ShellViewModel : EditableObjectViewModel<IWarehouseItem>
    {
        public ShellViewModel(IDataService dataService)
            : base(dataService.SingleItem)
        {
            //Model.NotifyOn("IsDirty", (o, o1) =>
            //{
            //    NotifyOfPropertyChange(() => IsDirty);
            //});
            //Model.NotifyOn("CanCancelChanges", (o, o1) => NotifyOfPropertyChange(() => CanCancelChanges));                   
        }

        protected override async Task<bool> SaveMethod(IWarehouseItem model)
        {
            //TODO: Add custom saving logic - handle exceptions, etc.
            await Task.Delay(50);
            return true;
        }

        private ICommand _undoCommand;
        public ICommand UndoCommand => _undoCommand ?? (_undoCommand = ActionCommand.When(() => 
        {
            return Model.CanUndo;
        }).Do(Model.Undo).RequeryOnPropertyChanged(Model, () => Model.CanUndo));

        private ICommand _redoCommand;
        public ICommand RedoCommand => _redoCommand ?? (_redoCommand = ActionCommand.When(() => Model.CanRedo).Do(Model.Redo).RequeryOnPropertyChanged(Model, () => Model.CanRedo));            
    }

    //public static class NotificationsHelper
    //{
    //    /// <summary>
    //    /// Subscribes supplied object to property changed notifications and invokes the provided callback        
    //    /// </summary>
    //    /// <typeparam name="T">Type of subject</typeparam><param name="subject">Subject</param><param name="path">Property path</param><param name="callback">Notification callback</param>
    //    public static void NotifyOn<T>(this T subject, string path, Action<object, object> callback)
    //      where T : INotifyPropertyChanged
    //    {
    //        Observable
    //            .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
    //                a => subject.PropertyChanged += a, a => subject.PropertyChanged -= a)
    //            .Where(a => a.EventArgs.PropertyName == path)
    //            .Subscribe(a => callback?.Invoke(new object(), new object()));
    //    }
    //}
}
