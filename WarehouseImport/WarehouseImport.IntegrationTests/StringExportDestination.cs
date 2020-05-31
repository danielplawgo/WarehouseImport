using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseImport.Exporters;

namespace WarehouseImport.IntegrationTests
{
    public class StringExportDestination : IExportDestination
    {
        public string Data { get; private set; }
        public Task WriteAsync(string value)
        {
            Data += value;

            return Task.CompletedTask;
        }
    }
}
