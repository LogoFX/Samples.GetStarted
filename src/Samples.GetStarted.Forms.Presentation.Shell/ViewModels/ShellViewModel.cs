using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using LogoFX.Core;
using Samples.Client.Model.Contracts;

namespace Samples.GetStarted.Forms.Presentation.Shell.ViewModels
{
    public class ShellViewModel : EditableObjectViewModel<IWarehouseItem>
    {
        public ShellViewModel(IDataService dataService)
            : base(dataService.SingleItem)
        {
            Model.NotifyOn("IsDirty", (o, o1) => NotifyOfPropertyChange(() => IsDirty));
            Model.NotifyOn("CanCancelChanges", (o, o1) => NotifyOfPropertyChange(() => CanCancelChanges));          
            this.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => 
            {
                if (e.PropertyName == "IsDirty" || e.PropertyName == "CanCancelChanges")
                {
                    
                }
            };
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

        private ICommand _testCommand;
        public ICommand TestCommand => _testCommand ?? (_testCommand = ActionCommand.When(() => true).Do(() =>
        {           
            NotifyOfPropertyChange(() => Model);
        }));
    }

    public static class NotificationsHelper
    {
        private static readonly WeakKeyDictionary<object, Dictionary<string, Action<object, object>>> _notifiers =
            new WeakKeyDictionary<object, Dictionary<string, Action<object, object>>>();
        
        /// <summary>
        /// Subscribes supplied object to property changed notifications and invokes the provided callback        
        /// </summary>
        /// <typeparam name="T">Type of subject</typeparam><param name="subject">Subject</param><param name="path">Property path</param><param name="callback">Notification callback</param>
        public static void NotifyOn<T>(this T subject, string path, Action<object, object> callback)
          where T : INotifyPropertyChanged
        {
            if (_notifiers.TryGetValue(subject, out var dictionary) == false)
            {
                _notifiers.Add(subject, dictionary = new Dictionary<string, Action<object, object>>());
            }

            dictionary.Remove(path);
                       
            subject.PropertyChanged += (sender, propertyChangedEventArgs) =>
            {
                if (propertyChangedEventArgs.PropertyName == path)
                {
                    dictionary[path]?.Invoke(new object(), new object());
                }
            };
            dictionary.Add(path, callback);
        }

        /// <summary>
        /// Unsubscribes supplied object from property changed notifications        
        /// </summary>
        /// <typeparam name="T">Type of subject</typeparam><param name="subject">Subject</param><param name="path">Property path</param>
        public static void UnNotifyOn<T>(this T subject, string path)
        {
            if (!_notifiers.TryGetValue(subject, out var dictionary) || !dictionary.ContainsKey(path))
                return;
            dictionary.Remove(path);
        }
    }
}
