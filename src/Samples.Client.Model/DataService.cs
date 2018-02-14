using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LogoFX.Client.Core;
using LogoFX.Core;
using Samples.Client.Model.Contracts;
using Samples.Client.Model.Fake;

namespace Samples.Client.Model
{
    [UsedImplicitly]
    internal sealed class DataService : NotifyPropertyChangedBase<DataService>, IDataService
    {              
        private readonly RangeObservableCollection<IWarehouseItem> _warehouseItems = new RangeObservableCollection<IWarehouseItem>();        
        private readonly WarehouseItemsStorage _storage = new WarehouseItemsStorage();

        public DataService()
        {           
            _storage.WithWarehouseItems(new[]
            {
                new WarehouseItem("PC", 25.43, 8),
                new WarehouseItem("Acme", 10, 10),
                new WarehouseItem("Bacme", 20, 3),
                new WarehouseItem("Exceed", 0.4, 100),
                new WarehouseItem("Acme2", 1, 2)                
            });
        }

        private async Task GetWarehouseItemsInternal()
        {
            await ServiceRunner.RunAsync(() =>
            {
                var warehouseItems = _storage.GetWarehouseItems();
                _warehouseItems.Clear();
                _warehouseItems.AddRange(warehouseItems);
            });
            
        }

        IEnumerable<IWarehouseItem> IDataService.WarehouseItems
        {
            get { return _warehouseItems; }
        }

        async Task IDataService.GetWarehouseItemsAsync()
        {
            await ServiceRunner.RunAsync(GetWarehouseItemsInternal);
        }

        async Task<IWarehouseItem> IDataService.NewWarehouseItemAsync()
        {
            await Task.Delay(1000);
            return new WarehouseItem("New Kind", 0d, 1)
            {
                IsNew = true
            };
        }

        async Task IDataService.SaveWarehouseItemAsync(IWarehouseItem item)
        {
            await ServiceRunner.RunAsync(() => _storage.SaveWarehouseItem(item));
        }

        async Task IDataService.DeleteWarehouseItemAsync(IWarehouseItem item)
        {
            await ServiceRunner.RunAsync(() =>
             {
                 _storage.DeleteWarehouseItem(item.Id);
                 _warehouseItems.Remove(item);
             });
        }        
    }
}
