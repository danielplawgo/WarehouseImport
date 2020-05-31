using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseImport.Warehouses
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly List<Warehouse> _warehouses = new List<Warehouse>();
        public IEnumerable<Warehouse> Warehouses => _warehouses;
        public Result Add(Warehouse warehouse)
        {
            var existingWarehouse = Warehouses.FirstOrDefault(w => w.Name == warehouse.Name);
            if (existingWarehouse != null)
            {
                return Result.Failure("warehouse exist");
            }
            _warehouses.Add(warehouse);

            return Result.Ok();
        }
    }

    public interface IWarehouseRepository
    {
        IEnumerable<Warehouse> Warehouses { get; }

        Result Add(Warehouse warehouse);
    }
}
