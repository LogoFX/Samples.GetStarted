using System;
using LogoFX.Client.Mvvm.Model.Contracts;

namespace Samples.Client.Model.Contracts
{    
    //TODO: Change Id type to another if needed: string, int, etc.
    public interface IAppModel : IModel<Guid>, IEditableModel, IUndoRedo
    {       
    }
}
