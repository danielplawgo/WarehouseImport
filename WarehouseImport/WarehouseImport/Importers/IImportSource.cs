using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseImport.Importers
{
    public interface IImportSource
    {
        Task<IEnumerable<string>> GetLinesAsync();
    }
}
