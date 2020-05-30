using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Warehouses
{
    public class Material
    {
        public Material(string name, string id)
        {
            Name = name;
            Id = id;
            Count = 0;
        }

        public string Name { get; }

        public string Id { get; }

        public int Count { get; private set; }
    }
}
