using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseImport.Exporters;
using WarehouseImport.Importers;

namespace WarehouseImport
{
    public class Application : IApplication
    {
        private readonly IImporter _importer;

        private readonly IExporter _exporter;

        public Application(IImporter importer,
            IExporter exporter)
        {
            _importer = importer;
            _exporter = exporter;
        }

        public async Task RunAsync()
        {
            await _importer.ImportAsync();

            await _exporter.ExportAsync();
        }
    }

    public interface IApplication
    {
        Task RunAsync();
    }
}
