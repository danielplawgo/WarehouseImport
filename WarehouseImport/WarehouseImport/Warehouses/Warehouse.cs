using System;
using System.Collections.Generic;
using System.Linq;
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

        public int Count { get; private set; }

        public void AddMaterial(string name, string id, int count)
        {
            var material = _materials.FirstOrDefault(m => m.Id == id);

            if (material == null)
            {
                material = new Material(name, id);
                _materials.Add(material);
            }
                
            material.AddCount(count);
            Count = count;
        }
    }
}
