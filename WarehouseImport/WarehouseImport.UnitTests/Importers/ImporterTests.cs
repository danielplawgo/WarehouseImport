using System;
using System.Collections.Generic;
using System.Text;
using WarehouseImport.Importers;

namespace WarehouseImport.UnitTests.Importers
{
    public class ImporterTests
    {
        protected virtual Importer Create()
        {
            return new Importer();
        }
    }
}
