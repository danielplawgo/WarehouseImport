using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseImport.Warehouses
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly List<Warehouse> _warehouses = new List<Warehouse>();
        public IEnumerable<Warehouse> Warehouses => _warehouses;
        public Task<Result> AddAsync(Warehouse warehouse)
        {
            var existingWarehouse = Warehouses.FirstOrDefault(w => w.Name == warehouse.Name);
            if (existingWarehouse != null)
            {
                return Result.FailureAsync("warehouse exist");
            }
            _warehouses.Add(warehouse);

            return Result.OkAsync();
        }
    }

    public interface IWarehouseRepository
    {
        IEnumerable<Warehouse> Warehouses { get; }

        Task<Result> AddAsync(Warehouse warehouse);
    }
}
