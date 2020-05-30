using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Importers
{
    public interface IImporter
    {
        Result Import();
    }
}
