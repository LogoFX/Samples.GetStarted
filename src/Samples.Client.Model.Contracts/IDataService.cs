﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samples.Client.Model.Contracts
{
    public interface IDataService
    {
        IEnumerable<IWarehouseItem> WarehouseItems { get; }

        Task GetWarehouseItemsAsync();

        Task<IWarehouseItem> NewWarehouseItemAsync();

        Task SaveWarehouseItemAsync(IWarehouseItem item);

        Task DeleteWarehouseItemAsync(IWarehouseItem item);       
    }
}
