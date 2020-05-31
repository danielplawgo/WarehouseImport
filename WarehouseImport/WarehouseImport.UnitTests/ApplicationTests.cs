using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using WarehouseImport.Importers;
using Xunit;

namespace WarehouseImport.UnitTests
{
    public class ApplicationTests
    {
        protected Mock<IImporter> Importer;

        protected virtual Application Create()
        {
            Importer = new Mock<IImporter>();
            return new Application(Importer.Object);
        }

        [Fact]
        public async void Run_Import()
        {
            var application = Create();

            await application.RunAsync();

            Importer.Verify(m => m.ImportAsync(), Times.Once);
        }
    }
}
