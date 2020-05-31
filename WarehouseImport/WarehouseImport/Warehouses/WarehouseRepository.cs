using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Warehouses
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly List<Warehouse> _warehouses = new List<Warehouse>();
        public IEnumerable<Warehouse> Warehouses => _warehouses;
        public Result Add(Warehouse warehouse)
        {
            throw new NotImplementedException();
        }
    }

    public interface IWarehouseRepository
    {
        IEnumerable<Warehouse> Warehouses { get; }

        Result Add(Warehouse warehouse);
    }
}
