using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Parsers
{
    public class MaterialImportCommand : ICommand
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public IEnumerable<WarehouseCount> Warehouses { get; set; }

        public class WarehouseCount
        {
            public string Name { get; set; }

            public int Count { get; set; }
        }
    }
}
