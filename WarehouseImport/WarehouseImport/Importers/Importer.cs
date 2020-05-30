using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Importers
{
    public class Importer : IImporter
    {
        private readonly IImportSource _importSource;

        public Importer(IImportSource importSource)
        {
            _importSource = importSource;
        }

        public Result Import()
        {
            var lines = _importSource.GetLines();
            
            return Result.Ok();
        }
    }
}
