using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using WarehouseImport.Importers;
using Xunit;

namespace WarehouseImport.UnitTests.Importers
{
    public class ImporterTests
    {
        protected Mock<IImportSource> ImportSource;

        protected IEnumerable<string> _lines = new List<string>()
        {
            "line1",
            "line2"
        };

        protected virtual Importer Create()
        {
            ImportSource = new Mock<IImportSource>();
            ImportSource.Setup(m => m.GetLines())
                .Returns(_lines);

            return new Importer(ImportSource.Object);
        }

        [Fact]
        public void Get_Lines_From_ImportSource()
        {
            var importer = Create();

            importer.Import();

            ImportSource.Verify(m => m.GetLines(), Times.Once);
        }
    }
}
