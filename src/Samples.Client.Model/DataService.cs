using JetBrains.Annotations;
using LogoFX.Client.Core;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model
{    
    [UsedImplicitly]
    internal sealed class DataService : NotifyPropertyChangedBase<DataService>, IDataService
    {        
        public IWarehouseItem SingleItem { get; } = new WarehouseItem("PC", 25.43, 8);        
    }
}
