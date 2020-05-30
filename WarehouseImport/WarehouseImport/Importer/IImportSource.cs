using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Importer
{
    public interface IImportSource
    {
        IEnumerable<string> GetLines();
    }
}
