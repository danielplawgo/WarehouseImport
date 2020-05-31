using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseImport.Exporters;

namespace WarehouseImport.Console
{
    public class ConsoleExportDestination : IExportDestination
    {
        public Task WriteAsync(string value)
        {
            System.Console.WriteLine(value);

            return Task.CompletedTask;
        }
    }
}
