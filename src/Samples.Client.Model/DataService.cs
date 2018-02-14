using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LogoFX.Client.Core;
using LogoFX.Core;
using Samples.Client.Data.Contracts.Providers;
using Samples.Client.Model.Contracts;
using Samples.Client.Model.Mappers;

namespace Samples.Client.Model
{
    [UsedImplicitly]
    internal sealed class DataService : NotifyPropertyChangedBase<DataService>, IDataService
    {
        private readonly IWarehouseProvider _warehouseProvider;        
        private readonly RangeObservableCollection<IWarehouseItem> _warehouseItems = new RangeObservableCollection<IWarehouseItem>();        

        public DataService(IWarehouseProvider warehouseProvider, IEventsProvider eventsProvider)
        {
            _warehouseProvider = warehouseProvider;           
        }

        private async Task GetWarehouseItemsInternal()
        {
            await ServiceRunner.RunAsync(() =>
            {
                var warehouseItems = _warehouseProvider.GetWarehouseItems().Select(WarehouseMapper.MapToWarehouseItem);
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
            var dto = WarehouseMapper.MapToWarehouseDto(item);
            if (item.IsNew)
            {
                await ServiceRunner.RunAsync(() => _warehouseProvider.CreateWarehouseItem(dto));
            }
            else
            {
                await ServiceRunner.RunAsync(() => _warehouseProvider.UpdateWarehouseItem(dto));
            }            
        }

        async Task IDataService.DeleteWarehouseItemAsync(IWarehouseItem item)
        {
            await ServiceRunner.RunAsync(() =>
             {
                 _warehouseProvider.DeleteWarehouseItem(item.Id);
                 _warehouseItems.Remove(item);
             });
        }        
    }
}
