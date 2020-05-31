using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using WarehouseImport.Exporters;
using WarehouseImport.Importers;
using Xunit;

namespace WarehouseImport.UnitTests
{
    public class ApplicationTests
    {
        protected Mock<IImporter> Importer;
        protected Mock<IExporter> Exporter;

        protected virtual Application Create()
        {
            Importer = new Mock<IImporter>();

            Exporter = new Mock<IExporter>();

            return new Application(Importer.Object, Exporter.Object);
        }

        [Fact]
        public async void Run_Import()
        {
            var application = Create();

            await application.RunAsync();

            Importer.Verify(m => m.ImportAsync(), Times.Once);
        }

        [Fact]
        public async void Run_Export()
        {
            var application = Create();

            await application.RunAsync();

            Exporter.Verify(m => m.ExportAsync(), Times.Once);
        }
    }
}
