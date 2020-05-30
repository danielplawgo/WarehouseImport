using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Warehouses
{
    public class Warehouse
    {
        private readonly List<Material> _materials = new List<Material>();

        public Warehouse(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IEnumerable<Material> Materials => _materials;
    }
}
