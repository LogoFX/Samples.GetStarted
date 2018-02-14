using System;
using System.Collections.Generic;
using System.Linq;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model.Fake
{
    public class WarehouseItemsStorage
    {
        private readonly List<IWarehouseItem> _warehouseItemsStorage = new List<IWarehouseItem>();                

        public void WithWarehouseItems(IEnumerable<IWarehouseItem> warehouseItems)
        {
            _warehouseItemsStorage.Clear();
            _warehouseItemsStorage.AddRange(warehouseItems);
        }       

        public IEnumerable<IWarehouseItem> GetWarehouseItems()
        {
            return _warehouseItemsStorage;
        }

        public bool DeleteWarehouseItem(Guid id)
        {
            var dto = _warehouseItemsStorage.SingleOrDefault(x => x.Id == id);
            if (dto == null)
            {
                return false;
            }
            return _warehouseItemsStorage.Remove(dto);
        }

        public void SaveWarehouseItem(IWarehouseItem dto)
        {
            var oldDto = _warehouseItemsStorage.SingleOrDefault(x => x.Id == dto.Id);
            if (oldDto == null)
            {
                _warehouseItemsStorage.Add(dto);
                return;
            }
            
            oldDto.Price = dto.Price;
            oldDto.Quantity = dto.Quantity;
        }
    }
}
