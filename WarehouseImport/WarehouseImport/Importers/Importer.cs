using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Result> ImportAsync()
        {
            var lines = await _importSource.GetLinesAsync();

            var parser = _parsers.FirstOrDefault(); //we can add some logic for getting correct parser

            foreach (var line in lines)
            {
                var commandResult = await parser.ParseAsync(line);
            }
            
            return Result.Ok();
        }
    }
}
