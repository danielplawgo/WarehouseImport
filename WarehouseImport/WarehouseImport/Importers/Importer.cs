using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseImport.Parsers;

namespace WarehouseImport.Importers
{
    public class Importer : IImporter
    {
        private readonly IImportSource _importSource;

        private readonly IParser[] _parsers;

        public Importer(IImportSource importSource,
            IParser[] parsers)
        {
            _importSource = importSource;
            _parsers = parsers;
        }

        public Result Import()
        {
            var lines = _importSource.GetLines();

            var parser = _parsers.FirstOrDefault(); //we can add some logic for getting correct parser

            foreach (var line in lines)
            {
                var commandResult = parser.Parse(line);
            }
            
            return Result.Ok();
        }
    }
}
