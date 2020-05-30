using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Importers
{
    public interface IImportSource
    {
        IEnumerable<string> GetLines();
    }
}
