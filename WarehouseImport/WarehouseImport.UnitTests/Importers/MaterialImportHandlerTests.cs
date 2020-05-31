using System;
using System.Collections.Generic;
using System.Text;
using WarehouseImport.Importers;
using WarehouseImport.Parsers;

namespace WarehouseImport.UnitTests.Importers
{
    public class MaterialImportHandlerTests
    {
        protected MaterialImportCommand Command = new MaterialImportCommand()
        {
            Id = "id",
            Name = "name",
            Warehouses = new List<MaterialImportCommand.WarehouseCount>()
            {
                new MaterialImportCommand.WarehouseCount()
                {
                    Name = "warehouse",
                    Count = 10
                }
            }
        };

        protected virtual MaterialImportHandler Create()
        {
            return new MaterialImportHandler();
        }
    }
}
