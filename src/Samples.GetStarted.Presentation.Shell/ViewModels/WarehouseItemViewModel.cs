﻿using Caliburn.Micro;
using LogoFX.Client.Mvvm.ViewModel;
using Samples.Client.Model.Contracts;

namespace Samples.GetStarted.Presentation.Shell.ViewModels
{    
    public class WarehouseItemViewModel : ObjectViewModel<IWarehouseItem>
    {
        public WarehouseItemViewModel(
            IWarehouseItem model) : base(model)
        {
        }

        
    }

    public class WarehouseItemCommandsViewModel : PropertyChangedBase
    {
        
    }
}
