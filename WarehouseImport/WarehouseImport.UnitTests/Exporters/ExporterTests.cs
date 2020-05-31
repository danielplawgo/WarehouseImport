using System;
using System.Collections.Generic;
using System.Text;
using WarehouseImport.Exporters;

namespace WarehouseImport.UnitTests.Exporters
{
    public class ExporterTests
    {
        protected virtual Exporter Create()
        {
            return new Exporter();
        }
    }
}
