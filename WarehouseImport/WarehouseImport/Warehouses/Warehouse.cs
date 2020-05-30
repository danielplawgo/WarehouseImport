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

        public void AddMaterial(string name, string id, int count)
        {
            var material = new Material(name, id);
            material.AddCount(count);

            _materials.Add(material);
        }
    }
}
