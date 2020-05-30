using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseImport.Importers
{
    public interface IImporter
    {
        Task<Result> ImportAsync();
    }
}
