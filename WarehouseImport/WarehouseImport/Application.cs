using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseImport.Importers;

namespace WarehouseImport
{
    public class Application : IApplication
    {
        private readonly IImporter _importer;

        public Application(IImporter importer)
        {
            _importer = importer;
        }

        public async Task RunAsync()
        {
            await _importer.ImportAsync();
        }
    }

    public interface IApplication
    {
        Task RunAsync();
    }
}
