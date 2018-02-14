using System;
using LogoFX.Client.Mvvm.Model.Contracts;

namespace Samples.Client.Model.Contracts
{    
    public interface IAppModel : IModel<Guid>, IEditableModel
    {
        /// <summary>
        /// Designates whether model should be discarded when cancelling changes        
        /// </summary>
        bool IsNew { get; set; }
    }
}
