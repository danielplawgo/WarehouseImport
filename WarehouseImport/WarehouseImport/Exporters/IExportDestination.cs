using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseImport.Exporters
{
    public interface IExportDestination
    {
        Task WriteAsync(string value);
    }
}
